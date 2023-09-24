using Barbari_DAL;

namespace Barbari_UI.SMS
{
    public class Creator : ICreator
    {
        public OperationResult<ISms> FacatoryMethod()
        {
            var result = Barbari_BLL.SMS.Select();
            if (result.Data != null)
            {
                if (result.Data.SMSName == "کاوه نگار")
                {
                    return new OperationResult<ISms>
                    {
                        Data = new Kavenegar(),
                        Success = true
                    };
                }
                else if (result.Data.SMSName == "ملی پیامک")
                {
                    return new OperationResult<ISms>
                    {
                        Data = new MeliPayamak(),
                        Success = true
                    };
                }
                else
                {
                    return new OperationResult<ISms>
                    {
                        Data = new sms_ir(),
                        Success = true
                    };
                }
            }
            else
            {
                return new OperationResult<ISms>
                {
                    Success = false,
                    Message = "لطفا ابتدا تنظیمات سامانه پیامکی را کامل کنید"
                };
            }
            
        }
    }
}
