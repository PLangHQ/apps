using PLang.Modules;
using System.ComponentModel;
using CountryValidation;
using PLang.Errors.Runtime;
using PLang.Errors;

namespace MyCountryValidator
{
    [Description("validates the national identity number and VAT numbers in multiple countries")]
    public class Program : BaseProgram
    {
        private readonly CountryValidator validator;

        public Program()
        {
            validator = new CountryValidator();
        }

        public async Task<(bool, IError)> IsSSNValid(string ssn, string country)
        {
            bool success = Enum.TryParse(typeof(Country), country, out var countryInstance);
            if (!success)
            {
                return (false, new ProgramError($"Country code {country} is not valid", goalStep, function));
            }
            var validationResult = validator.ValidateNationalIdentityCode(ssn, (Country) countryInstance);
            if (!validationResult.IsValid)
            {
				return (false, new ProgramError(validationResult.ErrorMessage, goalStep, function));
			}
            return (validationResult.IsValid, null);
        }

        public async Task<(bool, IError)> IsVATValid(string vat, string country)
        {
			bool success = Enum.TryParse(typeof(Country), country, out var countryInstance);
			if (!success)
			{
				return (false, new ProgramError($"Country code {country} is not valid", goalStep, function));
			}
			var validationResult = validator.ValidateVAT(vat, (Country)countryInstance);
			if (!validationResult.IsValid)
			{
				return (false, new ProgramError(validationResult.ErrorMessage, goalStep, function));
			}
			return (validationResult.IsValid, null);
        }
    }
}
