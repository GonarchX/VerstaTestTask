using DatabaseWorker.Models.ValidationAttribute;
using System.ComponentModel.DataAnnotations;

namespace DatabaseWorker.Models
{
    public class DeliveryOrder
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
        public bool IsDeleted { get; set; }
        public DeletedDeliveryOrderInfo? DeletedDeliveryOrderInfo { get; set; }
    }
}
