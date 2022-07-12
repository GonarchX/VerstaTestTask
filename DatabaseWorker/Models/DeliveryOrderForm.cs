using System.ComponentModel.DataAnnotations;
using DatabaseWorker.Models.ValidationAttribute;

namespace DatabaseWorker.Models
{
    public class DeliveryOrderForm
    {
        public int Id { get; set; }
        [Required]
        public string? SenderCity { get; set; }
        [Required]
        public string? SenderAddress { get; set; }
        [Required]
        public string? RecipientCity { get; set; }
        [Required]
        public string? RecipientAddress { get; set; }
        [Required]
        public float CargoWeight { get; set; }
        [Required]
        [DateNotLessThanNow]
        public DateTime CargoPickupDate { get; set; }

        public DeliveryOrderForm() { }

        public DeliveryOrderForm(int id, string? senderCity, string? senderAddress, string? recipientCity, string? recipientAddress, float cargoWeight, DateTime cargoPickupDate)
        {
            Id = id;
            SenderCity = senderCity;
            SenderAddress = senderAddress;
            RecipientCity = recipientCity;
            RecipientAddress = recipientAddress;
            CargoWeight = cargoWeight;
            CargoPickupDate = cargoPickupDate;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (CargoPickupDate < DateTime.Now)
            {
                results.Add(new ValidationResult("Start date and time must be greater than current time", new[] { "StartDateTime" }));
            }

            return results;
        }
    }
}
