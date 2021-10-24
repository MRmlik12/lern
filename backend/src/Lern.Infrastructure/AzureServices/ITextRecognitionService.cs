using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace Lern.Infrastructure.AzureServices
{
    public interface ITextRecognitionService
    {
        Task<IList<ReadResult>> GetReadTextAsync(string url);
    }
}