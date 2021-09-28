using System.ComponentModel.DataAnnotations;

namespace YooKassa.Api.Models
{
    public class CreatePaymentData
    {
        [Required]
        public string PaymentToken { get; init; }

        [Required]
        public string Price { get; init; }

        public string Description {  get; init; }
    }
}
