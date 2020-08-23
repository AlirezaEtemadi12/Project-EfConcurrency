using System.Collections.Generic;
using EfConcurrency.Common;
using Newtonsoft.Json;

namespace EfConcurrency.ServicesLayer.ViewModels.PublicViewModel
{
    public class ResponseObject<T>
    {
        public ResponseObject()
        {
            Errors = new List<string>();
        }

        [JsonIgnore]
        public MessageType StatusEnum { get; set; }

        public string Status => StatusEnum.ToString();

        public List<string> Errors { get; set; }

        public T Result { get; set; }

        public static ResponseObject<T> NotFound()
        {
            var result = new ResponseObject<T>()
            {
                StatusEnum = MessageType.NotFound
            };
            result.Errors.Add(ConstantSettings.NotFound);

            return result;
        }

        public static ResponseObject<T> Success()
        {
            return new ResponseObject<T>()
            {
                StatusEnum = MessageType.Success
            };
        }

        public static ResponseObject<T> Error()
        {
            var result = new ResponseObject<T>()
            {
                StatusEnum = MessageType.Error
            };
            result.Errors.Add(ConstantSettings.Error);

            return result;
        }

        public static ResponseObject<T> Unauthorized()
        {
            var result = new ResponseObject<T>()
            {
                StatusEnum = MessageType.Unauthorized
            };
            result.Errors.Add(ConstantSettings.Unauthorized);

            return result;
        }
    }
}
