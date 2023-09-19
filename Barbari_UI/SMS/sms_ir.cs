using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_UI.SMS
{
    public class sms_ir : ISms
    {
        public async Task<HttpResponseMessage> SendMessageAsync(string apiUrl, string phoneNumber, string message)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-sms-ir-secure-token" , apiUrl);

                var content = new StringContent($"{{\"message\": \"{message}\", \"receptor\": \"{phoneNumber}\"}}", Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://api.sms.ir/v1/send/likeToLike", content);
                return response;
            }
        }
    }
}
