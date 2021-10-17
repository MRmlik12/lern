using FluentValidation.TestHelper;
using Lern.Core.Models.Users.Settings;
using Lern.Core.Validators.Users.Settings;
using Xunit;

namespace Lern.UnitTests.Core.Validators.Options
{
    public class ChangePasswordValidatorTest
    {
        private readonly ChangePasswordModelValidator _validator;

        public ChangePasswordValidatorTest()
        {
            _validator = new ChangePasswordModelValidator();
        }

        [Fact]
        public void TestChangePasswordModel_Validate()
        {
            var changePasswordModel = new ChangePasswordModel
            {
                OldPassword = "exampleexample",
                NewPassword = "testtest"
            };

            Assert.True(_validator.TestValidate(changePasswordModel).IsValid);
        }
    }
}