using Defender.MoneyTracking.Application.Models.Sample;

namespace Defender.MoneyTracking.Application.Common.Interfaces;

public interface ISampleService
{
    Task<SampleResponse> GetSampleAsync();
}
