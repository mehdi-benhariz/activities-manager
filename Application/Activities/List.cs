using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{public class List{
    public class Query : IRequest<Result< List<Activity> >>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public bool IsGoing { get; set; }
        public bool IsHost { get; set; }
        public DateTime? StartDate { get; set; }
    }
    public class Handler : IRequestHandler<Query,Result< List<Activity>>>
    {
       private readonly DataContext _context;
        private readonly ILogger<List> _logger;

            public Handler(DataContext context, ILogger<List> logger)
       {
           _context = context;
           _logger = logger;
       }
       public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
       {
           var queryable = _context.Activities;
           _logger.LogInformation("Queryable: {queryable}", queryable);           
           var activities = await queryable.ToListAsync(cancellationToken);
            return Result<List<Activity>>.SuccessResult(activities);
       }
    }

}
    
}