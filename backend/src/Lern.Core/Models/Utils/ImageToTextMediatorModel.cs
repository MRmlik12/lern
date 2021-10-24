using System.Collections.Generic;
using Lern.Core.ProjectAggregate.Utils;
using MediatR;

namespace Lern.Core.Models.Utils
{
    public class ImageToTextMediatorModel : IRequest<List<PhraseItem>>
    {
        public string ImageData { get; set; }
    }
}