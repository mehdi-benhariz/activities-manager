using Application.Core;
using MediatR;
using Persistence;

namespace Application.Activities
{
  //delete activity
  public class Delete{
     public class Command : IRequest<Result<Unit> >{
        public Guid Id { get; set; }
    }
    public class Handler : IRequestHandler<Command,Result<Unit>>{
        private readonly DataContext _context;
         public  Handler(DataContext context)  {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {                
                var activity = await _context.Activities.FindAsync(request.Id);
                //cehck if activity exists
                if (activity == null)
                     return null;
                _context.Remove(activity);
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Result<Unit>.SuccessResult( Unit.Value);
                return Result<Unit>.FailureResult("Problem saving changes");
            }
        }

    }
  }
    

