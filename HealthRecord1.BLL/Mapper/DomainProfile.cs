using AutoMapper;
using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord1.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // Operation(Entity)  ==> OperationVM
            CreateMap<Operation,OperationVM>();
            // OperationVM ==> Operation(Entity)
            CreateMap<OperationVM, Operation>();

            // Patient(Entity)  => PatientVM
            CreateMap<Patient, PatientVM>();
            // PatientVM => Patient(Entity)
            CreateMap<PatientVM, Patient>();

            // Vaccination(Entity)  ==> VaccinationVM
            CreateMap<Vaccination, VaccinationVM>();
            // VaccinationVM==> Vaccination(Entity)
            CreateMap<VaccinationVM, Vaccination>();

            // ChronicDisease(Entity)  ==> ChronicDiseaseVM
            CreateMap<ChronicDisease, ChronicDiseaseVM>();
            // ChronicDiseaseVM ==> ChronicDisease(Entity)
            CreateMap<ChronicDiseaseVM, ChronicDisease>();
        }
    }
}
