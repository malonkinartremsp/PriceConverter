using PriceConverter.Models;
using System.Text;

namespace PriceConverter.ModelProvider
{
    public class PriceModelProvider : IPriceModelProvider
    {
        public PriceModel GetModel(decimal value)
        {
            return new PriceModel
            {
                Price = GetValue(value),
                Value = value
            };
        }

        private string GetValue(decimal value)
        {
            if (value == 0)
                return "You don't have money";

            var mainPart = GetMainPart((int)value);
            var deciamlPart = GetDecimalPart(value);

            return $"{mainPart} {deciamlPart}".Trim();
        }

        private string GetMainPart(int value)
        {
            if (value == 0)
                return string.Empty;

            var currency = value > 1 ? "dollars" : "dollar";
            var builder = new StringBuilder();

            var divider = 1000;

            while(value != 0)
            {
                if(divider > 10)
                {
                    var currentValue = value / divider;
                    if (currentValue > 0)
                    {
                        builder.Append($"{GetWordNumber(currentValue)} {GetWordNumber(divider)}");
                        builder.Append(" ");
                    }

                    value -= currentValue * divider;
                    divider /= 10;
                }
                else
                {
                    builder.Append(GetTwoDigitNumber(value));
                    value = 0;
                }
            }
            
            return $"{builder.ToString().Trim()} {currency}";
        }

        private string GetDecimalPart(decimal value)
        { 
            var round = (int)value;

            var dec = (int)((value - round) * 100);
            if (dec == 0)
                return string.Empty;

            string currency = dec > 1 ? "cents" : "cent";
            string hasMainPart = round > 0 ? "and" : string.Empty;

            return dec > 0 ? $"{hasMainPart} {GetTwoDigitNumber(dec)} {currency}" : string.Empty;
        }

        private string GetWordNumber(int value)
        {
            switch(value)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 10:
                    return "ten";
                case 11:
                    return "eleven";
                case 12:
                    return "twelve";
                case 13:
                    return "thirteen";
                case 14:
                    return "fourteen";
                case 15:
                    return "fifteen";
                case 16:
                    return "sixteen";
                case 17:
                    return "seventeen";
                case 18:
                    return "eighteen";
                case 19:
                    return "nineteen";
                case 20:
                    return "twenty";
                case 30:
                    return "thirty";
                case 40:
                    return "forty";
                case 50:
                    return "fifty";
                case 60:
                    return "sixty";
                case 70:
                    return "seventy";
                case 80:
                    return "eighty";
                case 90:
                    return "ninety";
                case 100:
                    return "hundred";
                case 1000:
                    return "thousand";
                default:
                    return string.Empty;
            }
        }

        private string GetTwoDigitNumber(int value)
        {
            if (value > 19)
            {
                var secondDigit = value % 10;

                if (secondDigit != 0)
                {
                    var main = GetWordNumber(value - secondDigit);
                    var second = GetWordNumber(secondDigit);

                    return $"{main}-{second}";
                }
            }

            return GetWordNumber(value);
        }
    }
}