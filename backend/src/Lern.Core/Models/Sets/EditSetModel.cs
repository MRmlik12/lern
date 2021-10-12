using System;

namespace Lern.Core.Models.Sets
{
    public record EditSetModel : CreateSetModel
    {
        public Guid Id { get; set; }
    }
}