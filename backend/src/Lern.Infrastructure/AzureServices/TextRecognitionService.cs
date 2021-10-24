using System;
using System.Collections.Generic;
using System.Threading;
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
                Endpoint = configuration.Endpoint,
            };
        }

        public Task<IList<ReadResult>> GetReadTextAsync(string url)
        {
            var operation = _client.ReadAsync(url).Result;
            var operationId = Guid.Parse(operation.OperationLocation.Split("/")[7].Split(".")[0]);
            Thread.Sleep(3000);
            var readResult = _client.GetReadResultAsync(operationId).Result;
            var result = readResult.AnalyzeResult.ReadResults;
            
            return Task.FromResult(result);
        }
    }
}