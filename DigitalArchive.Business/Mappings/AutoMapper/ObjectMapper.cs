using AutoMapper;
using DigitalArchive.Business.Mappings.AutoMapper.Profiles;

namespace DigitalArchive.Business.Mappings.AutoMapper
{
    public class ObjectMapper
    {
        private static Lazy<IConfigurationProvider> config = new Lazy<IConfigurationProvider>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BusinessProfile>();

            });
            return config;
        });

        private static Lazy<IMapper> mapper = new Lazy<IMapper>(() =>
        {
            var mapper = new Mapper(Configuration);
            return mapper;
        });

        public static IMapper Mapper
        {
            get { return mapper.Value; }
        }
        private static IConfigurationProvider Configuration
        {
            get { return config.Value; }
        }
    }
}
