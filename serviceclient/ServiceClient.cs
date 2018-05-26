using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace serviceclient
{
    public class ServiceClient<T> where T : class
    {
        private static HttpClient client = new HttpClient();

        public string Endpoint { get; set; }

        private DataContractJsonSerializer listSerializer = null;
        private DataContractJsonSerializer objectSerializer = new DataContractJsonSerializer(typeof(T));

        public ServiceClient(string endpoint) {
            Endpoint = endpoint;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            var serializerOptions = new DataContractJsonSerializerSettings()
            {
                EmitTypeInformation = EmitTypeInformation.Never
            };

            listSerializer = new DataContractJsonSerializer(typeof(List<T>), serializerOptions);
            objectSerializer = new DataContractJsonSerializer(typeof(T), serializerOptions);
        }

        public List<T> Get() {
            var stream = client.GetStreamAsync(Endpoint).Result;

            var result = listSerializer.ReadObject(stream) as List<T>;

            return result;
        }

        public T Get(string id)
        {
            var endpoint = Endpoint + $@"/{id}";
            var stream = client.GetStreamAsync(endpoint).Result;

            return objectSerializer.ReadObject(stream) as T;
        }
    }
}
