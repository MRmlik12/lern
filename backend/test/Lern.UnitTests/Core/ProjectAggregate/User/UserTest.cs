using System;
using Xunit;

namespace Lern.UnitTests.Core.ProjectAggregate.User
{
    public class UserTest
    {
        [Fact]
        public void TestUserTimestampType()
        {
            Assert.IsType<DateTimeOffset>(new Lern.Core.ProjectAggregate.User.User().CreateTimestamp().CreatedAt);
        }

        [Fact]
        public void TestUserIdType()
        {
            Assert.IsType<Guid>(new Lern.Core.ProjectAggregate.User.User().CreateTimestamp().Id);
        }

        [Fact]
        public void TestUserUpdatedAtType()
        {
            Assert.IsType<DateTimeOffset>(new Lern.Core.ProjectAggregate.User.User().UpdateTimestamp().UpdatedAt);
        }
    }
}