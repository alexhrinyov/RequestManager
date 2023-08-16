using AutoMapper;
using RequestManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManager.Infrastructure
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<LineProperties, LinePropertiesDomain>();
                cfg.CreateMap<LinePropertiesDomain, LineProperties>();
                cfg.CreateMap<TapOffBoxes, TapOffBoxesDomain>();
                cfg.CreateMap<Reductions, ReductionsDomain>();
                cfg.CreateMap<Line, LineDomain>();
                cfg.CreateMap<LineDomain,Line>()/*.ForMember("Properties", opt => opt.Ignore())*/; ;

                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
