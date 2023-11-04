using AutoMapper;
using MediTechSolution_mainProject.API.DTO;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using MediTechSolution_mainProject.API.Services.Repositories;

namespace MediTechSolution_mainProject.API.AutoMapperProfile
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, AddUserRequestDTO>().ReverseMap();
            CreateMap<AddHospitalCityNames, AddHospitalCityRequestDTO>().ReverseMap();
            CreateMap<MedicalDoctorSpeciality, AddMedicalSpecialityRequestDTO>().ReverseMap();
            CreateMap<CollegesModel, AddCollegesUniversityRequestDTO>().ReverseMap();
            CreateMap<CourseDetailsModel, AddCourseDetailRequestDTO>().ReverseMap();
            CreateMap<Doctor, AddDoctorRegisterDTO>().ReverseMap();
            CreateMap<FindADoctor, AddFindADoctorRequestDTO>().ReverseMap();
        }
    }
}
