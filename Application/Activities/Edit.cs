using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit{
        public class Command :IRequest{
        public Activity Activity{get;set;}
        }
        public class Handler : IRequestHandler<Command>{
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);
                if(activity == null)
                    return Unit.Value;
                activity.Title = request.Activity.Title ?? activity.Title;
                activity.Description = request.Activity.Description ?? activity.Description;
                activity.Category = request.Activity.Category ?? activity.Category; ;
                // activity.Date = request.Activity.Date ?? activity.Date ;
                activity.City = request.Activity.City ?? activity.City ;
                activity.Venue = request.Activity.Venue ?? activity.Venue ;
                var success = await _context.SaveChangesAsync() > 0;
                if(success)
                    return Unit.Value;
                throw new System.Exception("Problem saving changes");
            }
        }
    }
    
}