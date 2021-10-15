using System;
using Lern.Core.ProjectAggregate.Group;
using Lern.Core.Utils;
using Xunit;

namespace Lern.UnitTests.Core.Utils
{
    public class ShareCodeGeneratorUtilityTest
    {
        [Fact]
        public void TestGetShortCode()
        {
            var result = ShareCodeGeneratorUtility.GetShortCode(new Group().GenerateId().CreateTimestamp());
            
            Assert.IsType<string>(result);
            Assert.Equal(10, result.Length);
        }
    }
}