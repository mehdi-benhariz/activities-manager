using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
      public class Command : IRequest
      {
          public Activity Activity { get; set; }
            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;
                public Handler(DataContext dataContext)
                {
                    _context = dataContext;
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                { 
                    _context.Activities.Add(request.Activity);
                    var success = await _context.SaveChangesAsync() > 0;
                    if (success) return Unit.Value;
                    throw new System.Exception("Problem saving changes");
                }
            }
        }
    }
}