using Barbari_DAL;

namespace Barbari_UI.SMS
{
    public interface ICreator
    {
        OperationResult<ISms> FacatoryMethod();
    }
}
