using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lern.Core.Models.Sets.Stars
{
    public class AddStarMediatorModel : IRequest
    {
        public Guid UserId { get; set; }
        public Guid SetId { get; set; }
    }
}