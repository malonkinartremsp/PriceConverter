using PriceConverter.Models;

namespace PriceConverter.ModelProvider
{
    public interface IPriceModelProvider
    {
        PriceModel GetModel(decimal value);
    }
}