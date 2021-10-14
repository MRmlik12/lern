using System;
using System.Collections.Generic;

namespace Lern.Core.ProjectAggregate.Set.Dtos
{
    public class SetCardItemsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public List<string> Tags { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
}