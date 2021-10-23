using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lern.Core.Configuration;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace Lern.Infrastructure.AzureServices
{
    public class TextRecognitionService : ITextRecognitionService
    {
        private readonly ComputerVisionClient _client;
        
        public TextRecognitionService(AzureComputerVisionConfiguration configuration)
        {
            _client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(configuration.SubscriptionKey))
            {
                Endpoint = configuration.Endpoint
            };
        }

        public async Task<IList<ReadResult>> GetReadTextAsync(string url)
        {
            Console.WriteLine(url);
            var operation = await _client.ReadAsync(url);
            var operationId = Guid.Parse( operation.OperationLocation.Split("/")[7].Split(".")[0]);
            var result = await _client.GetReadResultAsync(operationId);

            return result.AnalyzeResult.ReadResults;
        }
    }
}