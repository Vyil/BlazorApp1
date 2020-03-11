using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace BlazorApp1.Data
{
    public class InformationService
    {
        private readonly IHttpClientFactory _clientFactory;
        public InformationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task getApiStuff(){
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://postman-echo.com/get?foo1=bar1&foo2=bar2");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            Console.WriteLine(response);
        }
        private static readonly List<InformationOneContent> informationOne;

        static InformationService()
        {
            informationOne = new List<InformationOneContent>
            {
                new InformationOneContent
                {
                    Title = "How to build a drone",
                    Content = "Buy all the required electrical parts and do something with it"
                },
                new InformationOneContent
                {
                    Title = "How to build a house",
                    Content = "Buy all the required stones and do something with it"
                }

            };
        }
        public Task<List<InformationOneContent>> GetInfoAsync()
        {
            return Task.FromResult(informationOne);
        }

    }
}
