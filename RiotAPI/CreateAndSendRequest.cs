using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RitoForCustoms.RiotAPI
{
    class CreateAndSendRequest
    {
        public async static Task<string> SendRequest(Uri myUri, HttpClient httpclient, string valAPI = null, string keyAPI = null)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = myUri;
            request.Method = HttpMethod.Get;
            if (valAPI != null && keyAPI != null)
                request.Headers.Add(valAPI, keyAPI);
            HttpResponseMessage response = await httpclient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;

        }
    }
}
