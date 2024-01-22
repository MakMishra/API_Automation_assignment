using Newtonsoft.Json;
using RestSharp;
using NUnit.Framework;
using API_Automation.Models;

namespace API_Automation.Utils

{
    public static class Helper
    {
        private static readonly RestClient client = new RestClient("https://www.localhost:8080/api");

        public static RestResponse<T> ExecuteRequest<T>(string resource, Method method, object requestBody = null)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", "application/json");

            if (requestBody != null)
            {
                request.AddJsonBody(requestBody);
            }

            return client.Execute<T>(request);
        }

        public static RestResponse ExecuteRequest(string resource, Method method, object requestBody = null)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", "application/json");

            if (requestBody != null)
            {
                request.AddJsonBody(requestBody);
            }

            return client.Execute(request);
        }

        public static T DeserializeResponse<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static void VerifyStatusCode(RestResponse response, int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)response.StatusCode);
        }

        public static void VerifyNoErrors(RestResponse response)
        {
            var apiResponse = DeserializeResponse<ApiResponse<object>>(response);
            Assert.IsEmpty(apiResponse.Errors);
        }
    }
}
