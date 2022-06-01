using AutoMapper;
using Examino.Application.Functions.Raports.Commands.CreateRaport;
using Examino.Application.Functions.Users.Registration.Command.RegisterPatient;
using Examino.Application.Functions.Users.UserDetails.UpdateUserDetails;
using Examino.Domain.DTOs;
using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterPatientCommand, Patient>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<CreateRaportCommand, Raport>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<UpdateUserDetailsCommand, UpdateUserDetailsDto>();

            CreateMap<UpdateUserDetailsDto, Patient>()
                .ForMember(x => x.Id, opt => opt.MapFrom(p => p.UserId))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForAllMembers(x => x.Condition((src, dest, sourceValue) => sourceValue != null));
        }
    }
}
