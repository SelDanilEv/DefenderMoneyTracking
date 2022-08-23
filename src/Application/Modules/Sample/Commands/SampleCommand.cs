using Defender.MoneyTracking.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Defender.MoneyTracking.Application.Modules.Sample.Commands;

public record SampleCommand : IRequest
{
    public Guid Id { get; set; }
};

public sealed class SampleCommandValidator : AbstractValidator<SampleCommand>
{
    public SampleCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("No id!");
    }
}

public sealed class SampleCommandHandler : IRequestHandler<SampleCommand>
{
    private readonly ISampleService _sampleService;

    public SampleCommandHandler(
        ISampleService sampleService)
    {
        _sampleService = sampleService;
    }

    public async Task<Unit> Handle(SampleCommand request, CancellationToken cancellationToken)
    {
        await _sampleService.GetSampleAsync();

        return Unit.Value;
    }
}
