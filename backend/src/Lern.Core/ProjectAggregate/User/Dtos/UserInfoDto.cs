using System;

namespace Lern.Core.ProjectAggregate.User.Dtos
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public long SetCount { get; set; }
        public long GroupsCount { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}