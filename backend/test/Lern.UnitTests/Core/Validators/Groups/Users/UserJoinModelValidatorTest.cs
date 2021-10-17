using FluentValidation.TestHelper;
using Lern.Core.Models.Groups.Users;
using Lern.Core.Validators.Groups.Users;
using Xunit;

namespace Lern.UnitTests.Core.Validators.Groups.Users
{
    public class UserJoinModelValidatorTest
    {
        private readonly UserJoinModelValidator _validator;

        public UserJoinModelValidatorTest()
        {
            _validator = new UserJoinModelValidator();
        }   
        
        [Fact]
        public void TestRegisterUserValidator_ChecksValidModel()
        {
            var model = new UserJoinModel()
            {
                Code = "OTY0MDA2OA"
            };
            
            Assert.True(_validator.TestValidate(model).IsValid);
        }
    }
}