using Barbari_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Barbari_UI.SMS
{

    public class SmsSender
    {
        private ISms _ISms;
        public SmsSender(ISms ms)
        { _ISms = ms; }
        public async Task<OperationResult> SendAsync(string API, string receptor, string message)
        {
            var result = await _ISms.SendMessageAsync(API, receptor, message);
            if (result.IsSuccessStatusCode)
            {
                return new OperationResult
                {
                    Success = true,
                    Message = "پیام ارسال شد"
                };
            }
            else
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "خطایی رخ داده است لطفا به پنل کاربری قسمت خطاهای وب سرویس مراجعه کنید"
                };
            }
        }
    }
}
