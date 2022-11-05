using AutoMapper;

namespace DigitalArchive.Business.Abstract
{
    public interface IBaseAppService
    {
        IMapper Mapper { get; }
    }
}
