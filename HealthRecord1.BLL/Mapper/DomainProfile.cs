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
            // Operation(Entity) ==> Operation(Entity)
            CreateMap<OperationVM, Operation>();
        }
    }
}
