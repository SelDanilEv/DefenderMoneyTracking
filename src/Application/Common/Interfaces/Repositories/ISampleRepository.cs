using Defender.MoneyTracking.Domain.Entities.Sample;

namespace Defender.MoneyTracking.Application.Common.Interfaces.Repositories;

public interface ISampleRepository
{
    Task<IList<SampleModel>> GetAllSamplesAsync();
    Task<SampleModel> GetSampleByIdAsync(Guid id);
    Task<SampleModel> CreateSampleAsync(SampleModel sample);
    Task<SampleModel> UpdateSampleAsync(SampleModel updatedSample);
    Task RemoveSampleAsync(Guid id);
}
