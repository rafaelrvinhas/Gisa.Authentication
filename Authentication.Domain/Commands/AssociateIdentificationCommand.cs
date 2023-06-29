using Authentication.Domain.Core.Commands;

namespace Authentication.Domain.Commands
{
    public abstract class AssociateIdentificationCommand : Command
    {
        public int AssociateId { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
        public int AssociateCategoryId { get; set; }
        public int PlanId { get; set; }
    }
}
