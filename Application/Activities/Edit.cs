using AutoMapper;
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
            private readonly IMapper _mapper;

            public Handler(DataContext context ,IMapper mapper){
                _context = context;
                _mapper = mapper;
            }
            public DataContext Context { get; }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);
                if(activity == null)
                    return Unit.Value;
             
                _mapper.Map(request.Activity,activity);
                var success = await _context.SaveChangesAsync() > 0;
                if(success)
                    return Unit.Value;
                throw new System.Exception("Problem saving changes");
            }
        }
    }
    
}