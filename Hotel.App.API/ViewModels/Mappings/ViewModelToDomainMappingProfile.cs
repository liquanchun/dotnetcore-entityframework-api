using AutoMapper;
using Hotel.App.Model;
using System.Collections.Generic;

namespace Hotel.App.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ScheduleViewModel, Schedule>()
               .ForMember(s => s.Creator, map => map.UseValue(null))
               .ForMember(s => s.Attendees, map => map.UseValue(new List<Attendee>()));

            Mapper.CreateMap<UserViewModel, User>();
        }
    }
}
