using MongoDB.Bson.Serialization.Attributes;

namespace Defender.MoneyTracking.Domain.Entities.Sample;

public class SampleModel : IBaseModel
{
    [BsonId]
    public Guid Id { get; set; }
}
