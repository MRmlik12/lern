using System;
using System.Collections.Generic;
using FluentValidation.TestHelper;
using Lern.Core.Models.Sets;
using Lern.Core.ProjectAggregate.Set;
using Lern.Core.Validators.Sets;
using Xunit;

namespace Lern.UnitTests.Core.Validators.Sets
{
    public class EditSetModelValidatorTest
    {
        private readonly EditSetModelValidator _validator;

        public EditSetModelValidatorTest()
        {
            _validator = new EditSetModelValidator();
        }

        [Fact]
        public void TestRegisterUserValidator_ChecksValidModel()
        {
            var model = new EditSetModel()
            {
                Id = Guid.NewGuid(),
                Title = "Foods",
                Language = "English",
                Tags = new List<string>
                {
                    "foods"
                },
                Items = new List<SetItem>
                {
                    new()
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