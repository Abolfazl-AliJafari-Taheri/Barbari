using Barbari_DAL;
using Stimulsoft.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_UI.SMS
{
    public class Kavenegar : ISms
    {
        public async Task<HttpResponseMessage> SendMessageAsync(string apiUrl, string phoneNumber, string message)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiUrl);

                var content = new StringContent($"{{\"message\": \"{message}\", \"receptor\": \"{phoneNumber}\"}}", Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://api.kavenegar.com/v1/"+apiUrl+"/sms/send.json", content);
                return response;
            }
        }

    }
}
