using System;
using System.Collections.Generic;

namespace Lern.Core.ProjectAggregate.Set.Dtos
{
    public class SetDto
    {
        public string Title { get; set; }
        public string Language { get; set; }
        public List<string> Tags { get; set; }
        public Guid UserId { get; set; }
        public List<SetItem> Items { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}