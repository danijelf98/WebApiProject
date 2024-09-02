using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApiProject.Shared.Services.Implementations
{
    public abstract class WebApiServiceClientBase
    {
        private readonly HttpClient httpClient;
        private readonly Action<HttpResponseMessage> unsuccessfulResponseAction;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        protected WebApiServiceClientBase(HttpClient httpClient, Action<HttpResponseMessage> unsuccessfulResponseAction)
        {
            this.httpClient = httpClient;
            this.unsuccessfulResponseAction = unsuccessfulResponseAction;
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        private HttpResponseMessage DoRequest(string url, HttpMethod httpMethod, object contentObj = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);
            if (contentObj != null)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(contentObj), Encoding.UTF8, "application/json");
                request.Content = content;
            }
            if (httpMethod == HttpMethod.Get)
            {
                return httpClient.SendAsync(request).Result;
            }
            if (httpMethod == HttpMethod.Delete)
            {
                return httpClient.DeleteAsync(url).Result;
            }
            if (httpMethod == HttpMethod.Put)
            {
                return httpClient.PutAsync(url, request.Content).Result;
            }

            return httpClient.PostAsync(url, request.Content).Result;
        }
        private T TryGetResponseContent<T>(HttpResponseMessage responseMessage, bool readResponseBody, Action<HttpResponseMessage> unsuccessfulResponseAction)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                if (readResponseBody)
                {
                    var response = responseMessage.Content.ReadAsStringAsync().Result;
                    var responseObj = JsonSerializer.Deserialize<T>(response, jsonSerializerOptions);
                    return responseObj;
                }
            }
            else
            {
                var action = unsuccessfulResponseAction ?? this.unsuccessfulResponseAction;
                action?.Invoke(responseMessage);
            }
            return default(T);
        }

        protected T DoRequestAndTryGetResponseContent<T>(string url, HttpMethod httpMethod, bool readResponseBody, Action<HttpResponseMessage> unsuccessfulResponseAction, object contentObj = null)
        {
            var responseMessage = DoRequest(url, httpMethod, contentObj: contentObj);
            return TryGetResponseContent<T>(responseMessage, readResponseBody, unsuccessfulResponseAction);
        }
    }
}
