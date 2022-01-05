using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
            // CreateMap<UserActivity, AttendeeDto>();
            // CreateMap<UserActivity, UserActivityDto>();
            // CreateMap<Activity, ActivityDto>().ForMember(dest => dest.Attendees, opt => opt.MapFrom(src => src.UserActivities));
            // CreateMap<UserActivity, UserActivityDto>();
        }
        
    }
    
}