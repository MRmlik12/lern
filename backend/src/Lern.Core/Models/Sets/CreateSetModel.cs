using System.Collections.Generic;
using Lern.Core.ProjectAggregate.Set;
using MediatR;

namespace Lern.Core.Models.Sets
{
    public class CreateSetModel : IRequest
    {
        public string Title { get; set; }
        public string Language { get; set; }
        public List<string> Tags { get; set; }
        public List<SetItem> Items { get; set; }
    }
}