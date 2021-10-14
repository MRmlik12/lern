using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Vulder.SharedKernel;

namespace Lern.Core.ProjectAggregate.Set
{
    public class Set : BaseEntity
    {
        public string Title { get; set; }
        public string Language { get; set; }
        
        [ForeignKey("Author")]
        public User.User User { get; set; }
        
        public List<string> Tags { get; set; }
        
        [Column(TypeName = "jsonb")]
        public List<SetItem> Items { get; set; }
        
        [ForeignKey("Stars")]
        public List<User.User> Stars { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public Set GenerateId()
        {
            Id = Guid.NewGuid();

            return this;
        }

        public Set CreateTimestamp()
        {
            CreatedAt = DateTimeOffset.Now;
            
            return this;
        }
        
        public Set UpdateTimestamp()
        {
            UpdatedAt = DateTimeOffset.Now;
            
            return this;
        }
    }
}