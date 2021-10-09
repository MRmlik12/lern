using System;

namespace Lern.Core.ProjectAggregate.User.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}