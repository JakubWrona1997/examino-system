using AutoMapper;
using Examino.Application.Functions.Prescriptions.Command.CreatePrescritpion;
using Examino.Application.Functions.Raports.Commands.CreateRaport;
using Examino.Application.Functions.Users.Commands.CreateDoctor;
using Examino.Application.Functions.Users.Commands.Registration.RegisterPatient;
using Examino.Application.Functions.Users.Commands.UpdateDoctorDetails;
using Examino.Application.Functions.Users.Commands.UpdatePatientDetails;
using Examino.Domain.DTOs;
using Examino.Domain.DTOs.UserDTOs;
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

            CreateMap<CreateRaportCommand, Raport>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .ForMember(r => r.Prescription, opt => opt.Ignore());

            CreateMap<UpdatePatientDetailsCommand, UpdatePatientDetailsDto>();

            CreateMap<UpdatePatientDetailsDto, Patient>()
                .ForMember(x => x.Id, opt => opt.MapFrom(p => p.UserId))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForAllMembers(x => x.Condition((src, dest, sourceValue) => sourceValue != null));

            CreateMap<UpdateDoctorDetailsCommand, UpdateDoctorDetailsDto>();

            CreateMap<UpdateDoctorDetailsDto, Doctor>()
                .ForMember(x => x.Id, opt => opt.MapFrom(p => p.UserId))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForAllMembers(x => x.Condition((src, dest, sourceValue) => sourceValue != null));

            CreateMap<PrescriptionRaportDto, CreatePrescritpionCommand>();

            CreateMap<CreatePrescritpionCommand, Prescription>();
            CreateMap<CreateDoctorCommand, Doctor>()
                .ForMember(x=>x.UserName,opt=>opt.MapFrom(x=>x.Email));
        }
    }
}
