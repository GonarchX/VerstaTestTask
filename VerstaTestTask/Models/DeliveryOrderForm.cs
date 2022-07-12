namespace VerstaTestTask.Models
{
    public class DeliveryOrderForm
    {
        public int Id { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddress { get; set; }
        public float CargoWeight { get; set; }
        public DateTime CargoPickupDate { get; set; }

        public DeliveryOrderForm() { }

        public DeliveryOrderForm(int id, string senderCity, string senderAddress, string recipientCity, string recipientAddress, float cargoWeight, DateTime cargoPickupDate)
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
