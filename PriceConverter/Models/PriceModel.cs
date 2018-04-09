using System.ComponentModel.DataAnnotations;

namespace PriceConverter.Models
{
    public class PriceModel
    {
        public string Price { get; set; }

        [Required, Range(0, 9999.99)]
        public decimal Value { get; set; } = 0;
    }
}