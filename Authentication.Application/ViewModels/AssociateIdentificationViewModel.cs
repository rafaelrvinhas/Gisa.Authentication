namespace Authentication.Application.ViewModels
{
    public class AssociateIdentificationViewModel
    {
        public int AssociateId { get; set; }
        public string? Email { get; set; }
        public string? DocumentNumber { get; set; }
        public int AssociateCategoryId { get; set; }
        public int PlanId { get; set; }

        public AssociateIdentificationViewModel()
        { }

        public AssociateIdentificationViewModel(int associateId, string email, string documentNumber, int associateCategoryId, int planId)
        {
            AssociateId = associateId;
            Email = email;
            DocumentNumber = documentNumber;
            AssociateCategoryId = associateCategoryId;
            PlanId = planId;
        }
    }
}
