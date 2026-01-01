using OrderAPI.Domain.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repository
{
    public class OrderRepository
    {
        private readonly OrderDbContext _context;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order AddOrder(Order order)
        {
            if (order == null)
            {
               return null;
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }
        /// <summary>
        /// find order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order FindOrderById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _context.Orders.Find(id);

        }
        /// <summary>
        /// Retrieves all orders from the data source.
        /// </summary>
        /// <remarks>If no orders are found, the method returns <see langword="null"/>.  Callers should
        /// check for a <see langword="null"/> return value to handle cases where no orders exist.</remarks>
        /// <returns>A list of all orders, or <see langword="null"/> if no orders are found.</returns>
        public List<Order> FindAllOrders()
        {
            var orders = _context.Orders.ToList();
            if (orders == null || orders.Count == 0)
            {
                return null;
            }
            return orders;
        }
        /// <summary>
        /// Updates an existing order in the database with the specified details.
        /// </summary>
        /// <remarks>This method updates the order in the database and saves the changes. Ensure that the
        /// provided <paramref name="id"/> corresponds to an existing order in the database.</remarks>
        /// <param name="order">The <see cref="Order"/> object containing the updated details. Cannot be <see langword="null"/>.</param>
        /// <param name="id">The unique identifier of the order to be updated. Must be greater than 0.</param>
        /// <returns>The updated <see cref="Order"/> object if the operation is successful; otherwise, <see langword="null"/> if
        /// the input is invalid.</returns>
        public Order UpdateOrder(Order order)
        {
            if (order == null)
                return null;
            _context.Orders.Update(order); // ça fonctionne si order est attaché
            _context.SaveChanges();
            return order;
        }


        /// <summary>
        /// Deletes the order with the specified identifier.
        /// </summary>
        /// <remarks>This method removes the order from the database and commits the changes. Ensure the
        /// specified  <paramref name="id"/> corresponds to an existing order before calling this method.</remarks>
        /// <param name="id">The unique identifier of the order to delete. Must be greater than 0.</param>
        public Order DeleteOrder(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var order = _context.Orders.Find(id);
            if (order is null)
                return null;
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return order;
        }

    }
}
