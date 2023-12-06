
namespace Spotify.Core.Exception
{
    public class BusinessException : System.Exception
    {
        public List<BusinessValidation> Errors { get; set; } = new List<BusinessValidation>();

        public BusinessException() { }

        public BusinessException(BusinessValidation validation)
        {
            this.AddError(validation);
        }

        public void AddError(BusinessValidation validation)
        {
            this.Errors.Add(validation);
        }

        public void ValidateAndThrow()
        {
            if (this.Errors.Any())
                throw this;
        }
    }

    public class BusinessValidation
    {
        public string ErrorName { get; set; } = "Erros de Validação";
        public string ErrorMessage { get; set; }
    }
}
