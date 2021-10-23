using System.Collections.Generic;
using MediatR;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace Lern.Core.Models.Utils
{
    public class ImageToTextMediatorModel : IRequest<IList<ReadResult>>
    {
        public string ImageUrl { get; set; }
    }
}