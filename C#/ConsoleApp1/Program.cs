using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace ConsoleApp1
{
    class Program
    {

        private readonly HttpClient _httpClient;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        async void JsonExample(dynamic enity, string accountId)
        {
            dynamic dynamicEntity = enity;
            JToken JsonObj = new JObject();
            JsonObj["dxc_street1"] = "Test";
            JsonObj["dxc_zippostalcode"] = dynamicEntity.Zippostalcode;
            JsonObj["dxc_city"] = dynamicEntity.City;
            JsonObj["dxc_cvr"] = dynamicEntity.CVR;
            JsonObj["dxc_country"] = dynamicEntity.Country;
            JsonObj["dxc_email"] = dynamicEntity.ContactEmail;
            JsonObj["dxc_name"] = dynamicEntity.ContactPersonName;
            JsonObj["dxc_Requestedby@odata.bind"] = $"/accounts({accountId})";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "dxc_addressrequests")
            {
                Content = new StringContent(JsonConvert.SerializeObject(JsonObj))
            };

            var response = await _httpClient.SendAsync(request);
        }
    }
}
