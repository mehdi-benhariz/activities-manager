using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
      public class Command : IRequest<Result<Unit> >
      {
          public Activity Activity { get; set; }
            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator() => RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
            public class Handler : IRequestHandler<Command, Result<Unit>>
            {
                private readonly DataContext _context;
                public Handler(DataContext dataContext)
                {
                    _context = dataContext;
                }

                public async Task<Result <Unit>> Handle(Command request, CancellationToken cancellationToken)
                { 
                    _context.Activities.Add(request.Activity);
                    var success = await _context.SaveChangesAsync() > 0;
                    if (success) return Result<Unit>.SuccessResult(Unit.Value);
                    return Result<Unit>.FailureResult("Error while saving changes");
                }
            }
        }
    }
}