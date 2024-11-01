using AutoMapper;
using DatabaseLibrary.Models;
using MeterMonitoring.Library.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMonitoring.Data.Mapper.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddMeterDto, MeterData>();
            CreateMap<NewClientRequestDto, ClientRequest>();
        }

    }
}
