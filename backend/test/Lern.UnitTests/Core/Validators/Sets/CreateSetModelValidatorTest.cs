using System.Collections.Generic;
using FluentValidation.TestHelper;
using Lern.Core.Models.Sets;
using Lern.Core.ProjectAggregate.Set;
using Lern.Core.Validators.Sets;
using Xunit;

namespace Lern.UnitTests.Core.Validators.Sets
{
    public class CreateSetModelValidatorTest
    {
        private readonly CreateSetModelValidator _validator;

        public CreateSetModelValidatorTest()
        {
            _validator = new CreateSetModelValidator();
        }   
        
        [Fact]
        public void TestRegisterUserValidator_ChecksValidModel()
        {
            var model = new CreateSetModel()
            {
                Title = "Foods",
                Language = "English",
                Tags = new List<string>
                {
                    "foods"
                },
                Items = new List<SetItem>
                {
                    new SetItem
                    {
                        PrimaryWord = "Apple",
                        TranslatedWord = "Apple"
                    }
                }
            };
            
            Assert.True(_validator.TestValidate(model).IsValid);
        }
    }
}