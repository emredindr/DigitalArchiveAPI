using DigitalArchive.Core.Dto.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DigitalArchive.Core.Extensions.ResponseAndExceptionMiddleware
{
    public class ApiResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ApiResponse);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            JToken checkItems = jObject.GetValue("items");
            JToken checkTotalCount = jObject.GetValue("totalCount");

            object response = null;
            if (checkItems != null)
            {
                if (checkTotalCount == null)
                {
                    response = JsonConvert.DeserializeObject<ListResult<object>>(jObject.ToString());
                }
                else
                {
                    response = JsonConvert.DeserializeObject<PagedResult<object>>(jObject.ToString());
                }
            }else
            {
                response = JsonConvert.DeserializeObject(jObject.ToString());
            }

            return new ApiResponse(ResponseMessageEnum.Success.GetDescription(), response);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
