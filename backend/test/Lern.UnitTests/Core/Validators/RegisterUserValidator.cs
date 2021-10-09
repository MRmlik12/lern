using FluentValidation.TestHelper;
using Lern.Core.Models.Users;
using Lern.Core.Validators;
using Xunit;

namespace Lern.UnitTests.Core.Validators
{
    public class RegisterUserValidatorTest
    {
        private readonly RegisterUserModelValidator _validator;

        public RegisterUserValidatorTest()
        {
            _validator = new RegisterUserModelValidator();
        }   
        
        [Fact]
        public void TestRegisterUserValidator_ChecksValidModel()
        {
            var model = new RegisterUserModel
            {
                Email = "example@example.com",
                Password = "qwertyuiop",
                Username = "example"
            };
            
            Assert.True(_validator.TestValidate(model).IsValid);
        }
    }
}