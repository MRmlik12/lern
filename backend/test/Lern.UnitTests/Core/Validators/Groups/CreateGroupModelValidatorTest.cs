using FluentValidation.TestHelper;
using Lern.Core.Models.Groups;
using Lern.Core.Validators.Groups;
using Xunit;

namespace Lern.UnitTests.Core.Validators.Groups
{
    public class CreateGroupModelValidatorTest
    {
        private readonly CreateGroupModelValidator _validator;

        public CreateGroupModelValidatorTest()
        {
            _validator = new CreateGroupModelValidator();
        }

        [Fact]
        public void TestRegisterUserValidator_ChecksValidModel()
        {
            var model = new CreateGroupModel()
            {
                Name = "ABCDEFG"
            };

            Assert.True(_validator.TestValidate(model).IsValid);
        }
    }
}