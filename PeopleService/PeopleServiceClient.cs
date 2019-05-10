using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeopleService
{
    /// <summary>
    /// Client for the agl-developer-test json web service
    /// </summary>
    public class PeopleServiceClient
    {
        public Uri ServiceBaseAddress { get; private set; }
        public HttpClient HttpClient {get;set;} 

        /// <summary>
        /// Create a new PeopleServiceClient
        /// </summary>
        /// <param name="serviceBaseAddress">The base url for the service excluding path to the json file</param>
        public PeopleServiceClient(string serviceBaseAddress)
        {
            bool result = Uri.TryCreate(serviceBaseAddress, UriKind.Absolute, out Uri uri);

            if (!result) throw new ArgumentException($"Invalid argument for PeopleService constructor: {serviceBaseAddress}");

            ServiceBaseAddress = uri;

            HttpClient = new HttpClient
            {
                BaseAddress = uri
            };
        }

        /// <summary>
        /// /people.json
        /// </summary>
        /// <returns>List of all people and their pets</returns>
        public async Task<PeopleModel> GetPeopleAsync()
        {
            var getAddress = new Uri(HttpClient.BaseAddress, "people.json");
            var response = await HttpClient.GetAsync(getAddress);
            response.EnsureSuccessStatusCode();
            var peopleList = await response.Content.ReadAsAsync<List<Person>>();
            return new PeopleModel(peopleList);
        }
    }
}
