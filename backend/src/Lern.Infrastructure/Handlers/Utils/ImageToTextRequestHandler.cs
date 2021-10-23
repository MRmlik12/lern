using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Utils;
using Lern.Infrastructure.AzureServices;
using MediatR;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace Lern.Infrastructure.Handlers.Utils
{
    public class ImageToTextRequestHandler : IRequestHandler<ImageToTextMediatorModel, IList<ReadResult>>
    {
        private readonly ITextRecognitionService _textRecognitionService;
        
        public ImageToTextRequestHandler(ITextRecognitionService textRecognitionService)
        {
            _textRecognitionService = textRecognitionService;
        }
        
        public async Task<IList<ReadResult>> Handle(ImageToTextMediatorModel request, CancellationToken cancellationToken)
        {
            return await _textRecognitionService.GetReadTextAsync(request.ImageUrl);
        }
    }
}