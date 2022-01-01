using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{public class List{
    public class Query : IRequest<List<Activity>  >
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public bool IsGoing { get; set; }
        public bool IsHost { get; set; }
        public DateTime? StartDate { get; set; }
    }
    public class Handler : IRequestHandler<Query, List<Activity>>
    {
       private readonly DataContext _context;
       public Handler(DataContext context)
       {
           _context = context;
       }
       public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
       {
           var queryable = _context.Activities;
        //    if (request.IsGoing && !request.IsHost)
           
        //        queryable = queryable.Where(x => x.UserActivities.Any(a => a.AppUser.UserName == request.UserName));
           
        //    if (request.IsHost && !request.IsGoing)
           
        //        queryable = queryable.Where(x => x.UserActivities.Any(a => a.AppUser.UserName == request.UserName && a.IsHost));
           
           var activities = await queryable.ToListAsync();
           return activities;
       }
    }

}
    
}