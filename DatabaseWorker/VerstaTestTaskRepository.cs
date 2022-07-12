﻿using DatabaseWorker.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseWorker
{
    internal class VerstaTestTaskRepository : IVerstaTestTaskRepository
    {
        private readonly VerstaTestTaskContext dbContext;
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

        public async Task<DeliveryOrderForm?> GetDeliveryOrderFormByIdAsync(int id)
        {
            DeliveryOrderForm? deliveryOrderForm = await dbContext.DeliveryOrderForms.FirstOrDefaultAsync(x => x.Id == id);
            return deliveryOrderForm;
        }

        public async Task AddDeliveryOrderFormsAsync(DeliveryOrderForm deliveryOrderForm)
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
            if (updatedDeliveryOrderForm == null)
            {
                throw new ArgumentNullException(nameof(updatedDeliveryOrderForm));
            }

            dbContext.Update(updatedDeliveryOrderForm);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteDeliveryOrderFormsAsync(int id)
        {
            DeliveryOrderForm? deliveryOrderForm = dbContext.DeliveryOrderForms.FirstOrDefault(x => x.Id == id)!;

            if (deliveryOrderForm == null)
            {
                throw new ArgumentNullException(nameof(deliveryOrderForm));
            }

            dbContext.DeliveryOrderForms.Remove(deliveryOrderForm);
            await dbContext.SaveChangesAsync();
        }
    }
}
