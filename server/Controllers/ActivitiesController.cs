using System.Collections.Generic;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace server.Controllers{
    //!public is importnat for the class to be visible to the outside world
    public class ActivitiesController : BaseApiController
    {
        public ActivitiesController(IMediator mediator) : base(mediator)
        {
        }

        // private readonly DataContext _context;

        [HttpGet(Name = "GetAllActivities")]
        public async Task<ActionResult<List<Activity> > > GetActivities(){

              return  Ok( await Mediator.Send(new List.Query()) );
        }
        // get one activity
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id){

            return Ok(await Mediator.Send(new Details.Query{Id = id}));
        }
        // create activity
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateActivity(Create.Command command,CancellationToken cancellationToken){

            return Ok(await Mediator.Send(command,cancellationToken));
        }
        // update activity
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> EditActivity(Guid id, Activity activity ){

            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
        }
        // delete activity
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteActivity(Guid id){
    
                return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}