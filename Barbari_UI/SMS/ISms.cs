using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_UI.SMS
{
    public interface ISms
    {
         Task<HttpResponseMessage> SendMessageAsync(string apiUrl, string phoneNumber, string message);
    }
}
