using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Lern.Core.Utils;
using Vulder.SharedKernel;

namespace Lern.Core.ProjectAggregate.Group
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        
        [ForeignKey("Admin")]
        public User.User User { get; set; }
        
        public List<Guid> MembersId { get; set; }
        
        public List<Guid> SetCollectionId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        
        public Group GenerateId()
        {
            Id = Guid.NewGuid();

            return this;
        }

        public Group CreateTimestamp()
        {
            CreatedAt = DateTimeOffset.Now;
            
            return this;
        }
        
        public Group UpdateTimestamp()
        {
            UpdatedAt = DateTimeOffset.Now;
            
            return this;
        }

        public Group GenerateCode()
        {
            Code = ShareCodeGeneratorUtility.GetShortCode(this);

            return this;
        }
    }
}