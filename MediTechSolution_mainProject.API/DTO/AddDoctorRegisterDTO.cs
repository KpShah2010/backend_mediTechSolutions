﻿namespace MediTechSolution_mainProject.API.DTO
{
    public class AddDoctorRegisterDTO
    {
        public string DoctorName { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string JoiningDate { get; set; }
        public string Password { get; set; }
        public string HospitalName { get; set; }
        public string State { get; set; }
        public string LicenseNumber { get; set; }
        public string Speciality { get; set; }
        public IFormFile DoctorImage { get; set; }
    }
}
