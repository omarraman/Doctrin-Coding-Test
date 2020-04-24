using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doctrin.Api.Resources;
using Doctrin.Core.Entities;

namespace Doctrin.Api.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain->Resource
            CreateMap<Unit, UnitResource>();
            CreateMap<Unit, SaveUnitResource>();
            CreateMap<Setting, SettingResource>();
            CreateMap<Setting, SaveSettingResource>();

            //Resource->Domain
            CreateMap<UnitResource, Unit>();
            CreateMap<SaveUnitResource, Unit>();
            CreateMap<SettingResource, Setting>();
            CreateMap<SaveSettingResource, Setting>();
        }
    }
}
