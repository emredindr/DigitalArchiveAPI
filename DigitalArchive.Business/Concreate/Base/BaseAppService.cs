using AutoMapper;
using DigitalArchive.Business.Abstract;
using DigitalArchive.Business.Mappings.AutoMapper;

namespace DigitalArchive.Business.Concreate
{
    public abstract class BaseAppService : IBaseAppService
    {
        public IMapper Mapper { get
            {
                return ObjectMapper.Mapper;
            }
        } 
    }
}
