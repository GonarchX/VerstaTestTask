using DatabaseWorker.Models;
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

        public async Task<List<DeliveryOrder>> GetDeliveryOrderFormsAsync()
        {
            List<DeliveryOrder> deliveryOrderForm = await dbContext.DeliveryOrder.ToListAsync();
            if (deliveryOrderForm == null)
            {
                throw new ArgumentNullException(nameof(deliveryOrderForm));
            }

            return deliveryOrderForm;
        }

        public async Task<DeliveryOrder?> GetDeliveryOrderFormByIdAsync(int id)
        {
            DeliveryOrder? deliveryOrderForm = await dbContext.DeliveryOrder.FirstOrDefaultAsync(x => x.Id == id);
            return deliveryOrderForm;
        }

        public async Task AddDeliveryOrderFormsAsync(DeliveryOrder deliveryOrderForm)
        {
            if (deliveryOrderForm == null)
            {
                throw new ArgumentNullException(nameof(deliveryOrderForm));
            }

            await dbContext.DeliveryOrder.AddAsync(deliveryOrderForm);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateDeliveryOrderFormsAsync(DeliveryOrder updatedDeliveryOrderForm)
        {
            if (updatedDeliveryOrderForm == null)
            {
                throw new ArgumentNullException(nameof(updatedDeliveryOrderForm));
            }

            dbContext.Update(updatedDeliveryOrderForm);
            await dbContext.SaveChangesAsync();
        }

        // TODO: При удалении значения просто переносить значение в другую таблицу
        public async Task DeleteDeliveryOrderFormsAsync(int id)
        {
            /*await using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    dbContext.Database.ExecuteSqlCommand(@"UPDATE People SET Age = Age + 1 WHERE Name = 'Sam'");
                    dbContext.People.Add(new Person { Age = 34, Name = "Bob" });
                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }*/


            DeliveryOrder? deliveryOrderForm = dbContext.DeliveryOrder.FirstOrDefault(x => x.Id == id)!;

            if (deliveryOrderForm == null)
            {
                throw new ArgumentNullException(nameof(deliveryOrderForm));
            }

            dbContext.DeliveryOrder.Remove(deliveryOrderForm);
            await dbContext.SaveChangesAsync();
        }
    }
}
