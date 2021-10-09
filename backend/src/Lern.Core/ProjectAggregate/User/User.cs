using System;
using Vulder.SharedKernel;

namespace Lern.Core.ProjectAggregate.User
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        
        public User GenerateId()
        {
            Id = Guid.NewGuid();
            
            return this;
        }

        public User CreateTimestamp()
        {
            CreatedAt = DateTimeOffset.Now;
            
            return this;
        }
        
        public User UpdateTimestamp()
        {
            UpdatedAt = DateTimeOffset.Now;
            
            return this;
        }
    }
}