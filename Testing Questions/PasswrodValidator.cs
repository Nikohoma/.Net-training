using System; // String
using System.Collections.Generic; // List
using NUnit.Framework.Legacy; // NUnit
using System.Text.RegularExpressions;

namespace ItTechGenie.M1.NUnit.Q3
{
    public record PasswordRules(int MinLen, bool MustHaveUpper, bool MustHaveDigit, bool MustHaveSpecial);
    public record ValidationResult(bool IsValid, List<string> Errors);

    public static class PasswordValidator
    {
        // ✅ TODO: Student must implement only this method
        public static ValidationResult Validate(string password, PasswordRules rules)
        {
            // TODO:
            // - trim leading/trailing spaces
            // - check length >= MinLen
            // - check uppercase if required
            // - check digit if required
            // - check special char if required (non-letter/digit)
            // - return ValidationResult
            bool IsValidCheck = true; List<string> Errors = new List<string>();
            password = password.Trim();
            if (password.Length < rules.MinLen) { IsValidCheck = false; Errors.Add("MIN_LEN");}
            if (rules.MustHaveUpper)
            {
                if (!password.Any(char.IsUpper)) { IsValidCheck = false; Errors.Add("MUST_HAVE_UPPER");}
                
            }
            if (rules.MustHaveDigit)
            {
                bool HasDigit = Regex.IsMatch(password, @"[0-9]+");
                if (!HasDigit) { IsValidCheck = false; Errors.Add("MUST_HAVE_DIGIT");  }
            }
            if (rules.MustHaveSpecial)
            {
                bool HasSpecial = Regex.IsMatch(password, @"[^0-9A-Za-z.,]");
                if (!HasSpecial) { IsValidCheck = false; Errors.Add("MUST_HAVE_SPECIAL"); }
            }
            return new ValidationResult(IsValidCheck, Errors);
        }
    }

    [TestFixture]
    public class PasswordValidatorTests
    {
        private PasswordRules _rules;

        [SetUp]
        public void SetUp()
        {
            _rules = new PasswordRules(8, true, true, true);                    // common rules
        }

        [Test]
        public void Validate_Should_ReturnInvalid_ForShortPassword()
        {
            var r = PasswordValidator.Validate("1234", _rules);                  // short

            Assert.That(r.IsValid, Is.False);
            Assert.That(r.Errors, Does.Contain("MIN_LEN"));
        }

        [Test]
        public void Validate_Should_Allow_InternalSpaces_AndUnicode()
        {
            var r = PasswordValidator.Validate(" P@ss w0rd ✅ ", _rules);

            Assert.That(r.IsValid, Is.True);
            Assert.That(r.Errors, Is.Empty);
        }
    }
}