using AutoMapper;
using Examino.Application.Functions.Prescriptions.Events.CreatePrescritpion;
using Examino.Application.Functions.Raports.Queries.GetUserRaports;
using Examino.Application.Functions.Users.Commands.CreateDoctor;
using Examino.Application.Functions.Users.Commands.Registration.RegisterPatient;
using Examino.Domain.DTOs.Doctor;
using Examino.Domain.DTOs.Patient;
using Examino.Domain.Entities;
using Examino.Domain.Requests.Doctors.Update;
using Examino.Domain.Requests.Patients.Update;
using Examino.Domain.Requests.Raports;

namespace Examino.Application.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterPatientCommand, Patient>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<UpdatePatientDetailsRequest, UpdatePatientDetailsDto>();

            CreateMap<UpdatePatientDetailsDto, Patient>()
                .ForMember(x => x.Id, opt => opt.MapFrom(p => p.UserId))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForAllMembers(x => x.Condition((src, dest, sourceValue) => sourceValue != null));

            CreateMap<UpdateDoctorDetailsRequest, UpdateDoctorDetailsDto>();

            CreateMap<UpdateDoctorDetailsDto, Doctor>()
                .ForMember(x => x.Id, opt => opt.MapFrom(p => p.UserId))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForAllMembers(x => x.Condition((src, dest, sourceValue) => sourceValue != null));

            CreateMap<CreateRaportRequest, Raport>()
                .ForMember(x => x.Prescription, opt => opt.Ignore());

            CreateMap<CreatePrescritpionEvent, Prescription>();

            CreateMap<CreateDoctorCommand, Doctor>()
                .ForMember(x=>x.UserName,opt=>opt.MapFrom(x=>x.Email));

            CreateMap<RaportDto, RaportViewModel>()
                .ForMember(x=>x.PrescritpionId, opt => opt.MapFrom(x=>x.PrescriptionsId));
        }
    }
}
