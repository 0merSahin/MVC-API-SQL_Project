using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiRequestTest.Classes
{
	public static class RequestTest
	{

		static async Task Main(string[] args)
        {
            // Docker container'ının IP adresi
            string dockerApiUrl = "http://docker_container_ip:docker_container_port";

            // HTTP GET isteği
            await SendHttpGetRequest(dockerApiUrl);

            // HTTP POST isteği
            await SendHttpPostRequest(dockerApiUrl);
        }


        static async Task SendHttpGetRequest(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("HTTP GET İstek Sonucu: " + content);
                }
                else
                {
                    Console.WriteLine("HTTP GET İstek Başarısız: " + response.StatusCode);
                }
            }
        }

        static async Task SendHttpPostRequest(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                // HTTP POST isteği için uygun content ekleyebilirsiniz
                var content = new StringContent("{'key':'value'}", System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("HTTP POST İstek Sonucu: " + result);
                }
                else
                {
                    Console.WriteLine("HTTP POST İstek Başarısız: " + response.StatusCode);
                }
            }
        }
    }
}

