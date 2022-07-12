using DatabaseWorker.Models;

namespace DatabaseWorker
{
    public interface IVerstaTestTaskRepository
    {
        Task<List<DeliveryOrderForm>> GetDeliveryOrderFormsAsync();
        Task<DeliveryOrderForm> GetDeliveryOrderFormByIdAsync(int id);
        Task CreateDeliveryOrderFormsAsync(DeliveryOrderForm deliveryOrderForm);
        Task UpdateDeliveryOrderFormsAsync(DeliveryOrderForm deliveryOrderForm);
        Task DeleteDeliveryOrderFormsAsync(int id);
    }
}
