namespace Authentication.Domain.Commands
{
    public class SaveAssociateIdentificationCommand : AssociateIdentificationCommand
    {
        public SaveAssociateIdentificationCommand(int associateId, string email, string documentNumber, int planId)
        {
            AssociateId = associateId;
            Email = email;
            DocumentNumber = documentNumber;
            PlanId = planId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
