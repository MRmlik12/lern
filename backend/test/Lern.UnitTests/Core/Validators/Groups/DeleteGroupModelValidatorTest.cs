using System;
using FluentValidation.TestHelper;
using Lern.Core.Models.Groups;
using Lern.Core.Validators.Groups;
using Xunit;

namespace Lern.UnitTests.Core.Validators.Groups
{
    public class DeleteGroupModelValidatorTest
    {
        private readonly DeleteGroupModelValidator _validator;

        public DeleteGroupModelValidatorTest()
        {
            _validator = new DeleteGroupModelValidator();
        }   
        
        [Fact]
        public void TestDeleteGroupValidator_ChecksValidModel()
        {
            var model = new DeleteGroupModel
            {
                GroupId = Guid.NewGuid()
            };
            
            Assert.True(_validator.TestValidate(model).IsValid);
        }
    }
}