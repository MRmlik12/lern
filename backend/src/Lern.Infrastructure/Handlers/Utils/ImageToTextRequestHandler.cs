using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lern.Core.Models.Utils;
using Lern.Core.ProjectAggregate.Utils;
using Lern.Infrastructure.AzureServices;
using Lern.Infrastructure.Cloudinary.Interfaces;
using MediatR;

namespace Lern.Infrastructure.Handlers.Utils
{
    public class ImageToTextRequestHandler : IRequestHandler<ImageToTextMediatorModel, List<PhraseItem>>
    {
        private readonly ITextRecognitionService _textRecognitionService;
        private readonly IUploadImageService _uploadImageService;
        
        public ImageToTextRequestHandler(ITextRecognitionService textRecognitionService, IUploadImageService uploadImageService)
        {
            _textRecognitionService = textRecognitionService;
            _uploadImageService = uploadImageService;
        }
        
        public async Task<List<PhraseItem>> Handle(ImageToTextMediatorModel request, CancellationToken cancellationToken)
        {
            var imageUrl = await _uploadImageService.UploadImage(request.ImageData, Guid.NewGuid());
            var imageResults = await _textRecognitionService.GetReadTextAsync(imageUrl);

            return (from line in imageResults[0].Lines where line.Words.Count != 1 select new PhraseItem { PrimaryWord = line.Words[0].Text, TranslatedWord = line.Words[1].Text }).ToList();
        }
    }
}