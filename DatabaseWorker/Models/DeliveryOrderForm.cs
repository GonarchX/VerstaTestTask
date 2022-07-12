using System.ComponentModel.DataAnnotations;

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
    }
}
