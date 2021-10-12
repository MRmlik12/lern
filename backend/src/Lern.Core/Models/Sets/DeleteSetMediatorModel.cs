using System;
using MediatR;

namespace Lern.Core.Models.Sets
{
    public class DeleteSetMediatorModel : IRequest
    {
        public Guid UserId { get; set; }
        public Guid SetId { get; set; }
    }
}