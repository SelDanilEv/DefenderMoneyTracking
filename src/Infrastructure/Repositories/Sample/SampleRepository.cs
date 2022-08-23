using Defender.MoneyTracking.Application.Common.Interfaces.Repositories;
using Defender.MoneyTracking.Application.Configuration.Options;
using Defender.MoneyTracking.Domain.Entities.Sample;
using Microsoft.Extensions.Options;

namespace Defender.MoneyTracking.Infrastructure.Repositories.Sample;

public class SampleRepository : MongoRepository<SampleModel>, ISampleRepository
{
    public SampleRepository(IOptions<MongoDbOption> mongoOption) : base(mongoOption.Value)
    {
    }

    public async Task<IList<SampleModel>> GetAllSamplesAsync()
    {
        return await GetItemsAsync();
    }

    public async Task<SampleModel> GetSampleByIdAsync(Guid id)
    {
        return await GetItemAsync(id);
    }

    public async Task<SampleModel> CreateSampleAsync(SampleModel sample)
    {
        return await AddItemAsync(sample);
    }

    public async Task<SampleModel> UpdateSampleAsync(SampleModel updatedSample)
    {
        return await UpdateItemAsync(updatedSample);
    }

    public async Task RemoveSampleAsync(Guid id)
    {
        await RemoveItemAsync(id);
    }
}
