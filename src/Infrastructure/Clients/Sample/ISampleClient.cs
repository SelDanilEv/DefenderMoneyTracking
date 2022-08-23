using Defender.MoneyTracking.Application.Models.Sample;

namespace Defender.MoneyTracking.Infrastructure.Clients.Interfaces;
public interface ISampleClient
{
    Task<SampleResponse> GetSampleAsync();
}
