using Authentication.Services.Api.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Domain.Models;
using Authentication.Application.ViewModels;
using Authentication.Application.Interfaces;
using Authentication.Domain.Core.Bus;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Services.Api.Controllers
{
    [Route("api/autenticacao")]
    public class AuthenticationController : ApiController
    {
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IAuthenticationAppService _authenticationAppService;

        public AuthenticationController(
            SignInManager<Account> signInManager,
            UserManager<Account> userManager,
            IOptions<AppSettings> appSettings,
            IAuthenticationAppService authenticationAppService,
            IMediatorHandler mediator) : base(mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _authenticationAppService = authenticationAppService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([Required][FromBody]UserLogin login)
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return BadRequest(login);
            }

            AssociateIdentificationViewModel associateIdentification = _authenticationAppService.GetByEmail(login.Email);

            if (associateIdentification == null)
            {
                return BadRequest("Usuário e/ou senha inválido(s).");
            }

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, true);

            if (result.Succeeded)
            {
                var token = await GenerateJwt(
                    login.Email, 
                    associateIdentification.AssociateId, 
                    associateIdentification.AssociateCategoryId);

                return Ok(token);
            }

            //NotifyError("Login", result.ToString());
            return BadRequest(login);
        }

        [Route("usuario/novo")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                //NotifyModelStateErrors();
                return BadRequest(userRegistration);
            }

            AssociateIdentificationViewModel associateIdentification = _authenticationAppService.GetByDocumentNumber(userRegistration.DocumentNumber);

            if (associateIdentification == null)
            {
                return BadRequest("Associado não encontrado.");
            }

            var user = new Account(
                userRegistration.Email, 
                userRegistration.Email, 
                true, 
                userRegistration.DocumentNumber, 
                (int)userRegistration.UserType);

            var result = await _userManager.CreateAsync(user, userRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    //NotifyError(error.Code, error.Description);
                }

                return BadRequest(userRegistration);
            }

            await _signInManager.SignInAsync(user, false);
            var token = await GenerateJwt(
                userRegistration.Email,
                associateIdentification.AssociateId,
                associateIdentification.AssociateCategoryId);

            return Ok(token);
        }

        private async Task<string> GenerateJwt(string? email, int associateId, int associateCategoryId)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sid, associateId.ToString() + ";" + associateCategoryId.ToString()));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidAt,
                Expires = DateTime.UtcNow.AddHours(_appSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
