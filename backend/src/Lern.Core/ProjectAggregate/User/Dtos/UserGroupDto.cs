using System;

namespace Lern.Core.ProjectAggregate.User.Dtos
{
    public class UserGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerUsername { get; set; }
        public int UserCount { get; set; }
    }
}