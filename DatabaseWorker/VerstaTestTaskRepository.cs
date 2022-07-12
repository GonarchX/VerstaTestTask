using DatabaseWorker.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseWorker
{
    internal class VerstaTestTaskRepository : IVerstaTestTaskRepository
    {
        private VerstaTestTaskContext dbContext;
        public VerstaTestTaskRepository(VerstaTestTaskContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<DeliveryOrderForm>> GetDeliveryOrderFormsAsync()
        {
            List<DeliveryOrderForm> deliveryOrderForm = (await dbContext.DeliveryOrderForms.ToListAsync())!;
            if (deliveryOrderForm == null)
            {
                throw new ArgumentNullException(nameof(deliveryOrderForm));
            }

            return deliveryOrderForm;
        }

        public async Task<DeliveryOrderForm> GetDeliveryOrderFormByIdAsync(int id)
        {
            DeliveryOrderForm deliveryOrderForm = (await dbContext.DeliveryOrderForms.FirstOrDefaultAsync(x => x != null && x.Id == id))!;
            if (deliveryOrderForm == null)
            {
                throw new ArgumentNullException(nameof(deliveryOrderForm));
            }

            return deliveryOrderForm;
        }

        public async Task CreateDeliveryOrderFormsAsync(DeliveryOrderForm deliveryOrderForm)
        {
            if (deliveryOrderForm == null)
            {
                throw new ArgumentNullException(nameof(deliveryOrderForm));
            }
            await dbContext.DeliveryOrderForms.AddAsync(deliveryOrderForm);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateDeliveryOrderFormsAsync(DeliveryOrderForm updatedDeliveryOrderForm)
        {
            dbContext.Update(updatedDeliveryOrderForm);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteDeliveryOrderFormsAsync(int id)
        {
            DeliveryOrderForm deliveryOrderForm = dbContext.DeliveryOrderForms.FirstOrDefault(x => x != null && x.Id == id)!;
            if (deliveryOrderForm == null)
            {
                throw new ArgumentNullException(nameof(deliveryOrderForm));
            }

            dbContext.DeliveryOrderForms.Remove(deliveryOrderForm);
            await dbContext.SaveChangesAsync();
        }
    }
}
