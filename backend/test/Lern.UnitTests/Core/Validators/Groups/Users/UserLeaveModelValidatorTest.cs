using System;
using FluentValidation.TestHelper;
using Lern.Core.Models.Groups.Users;
using Lern.Core.Validators.Groups.Users;
using Xunit;

namespace Lern.UnitTests.Core.Validators.Groups.Users
{
    public class UserLeaveModelValidatorTest
    {
        private readonly UserLeaveModelValidator _validator;

        public UserLeaveModelValidatorTest()
        {
            _validator = new UserLeaveModelValidator();
        }

        [Fact]
        public void TestRegisterUserValidator_ChecksValidModel()
        {
            var model = new UserLeaveModel()
            {
                GroupId = Guid.NewGuid()
            };

            Assert.True(_validator.TestValidate(model).IsValid);
        }
    }
}