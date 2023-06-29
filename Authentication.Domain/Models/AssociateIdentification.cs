using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Domain.Models
{
    [Table(name: "AssociateIdentification", Schema = "dbo")]
    public class AssociateIdentification
    {
        [Column(name: "AssociateId", TypeName = "int")]
        public int AssociateId { get; set; }

        [Column(name: "Email", TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(name: "DocumentNumber", TypeName = "varchar(11)")]
        public string DocumentNumber { get; set; }

        [Column(name: "AssociateCategoryId", TypeName = "int")]
        public int AssociateCategoryId { get; set; }

        [Column(name: "PlanId", TypeName = "int")]
        public int PlanId { get; set; }

        public AssociateIdentification(int associateId, string email, string documentNumber, int associateCategoryId, int planId)
        {
            AssociateId = associateId;
            Email = email;
            DocumentNumber = documentNumber;
            AssociateCategoryId = associateCategoryId;
            PlanId = planId;
        }
    }
}
