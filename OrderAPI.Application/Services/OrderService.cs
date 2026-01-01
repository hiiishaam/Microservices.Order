using OrderAPI.Domain.Entities;
using OrderAPI.Infrastructure.Repository;
using OrderAPI.Application.DTOs;

namespace OrderAPI.Application.Services
{
    public class OrderService
    {
        private readonly OrderRepository _repo;
        public OrderService(OrderRepository repo)
        {
            _repo = repo;
        }
        public Order AddOrder(OrderDTO odrer)
        {
            try
            {
                if (odrer == null)
                {
                    throw new Exception("Product is required");
                }
                var order = new Order
                {
                    ProductId = odrer.ProductId,
                    Quantity = odrer.Quantity,
                    OrderDate = odrer.OrderDate,
                    TotalPrice = odrer.TotalPrice
                };
                return _repo.AddOrder(order);
            }
            catch (Exception)
            {
                throw new Exception("Error to add Product");
            }
        }
        public Order FindOrderById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Id is required");
                }
                return _repo.FindOrderById(id);
            }
            catch (Exception)
            {
                throw new Exception("Error to find Product by id");
            }
        }
        public List<Order> FindAllOrders()
        {
            try
            {
                return _repo.FindAllOrders();
            }
            catch (Exception)
            {
                throw new Exception("Error to find all Products");
            }
        }
        public Order UpdateOrder(UpdateOrderDTO orderDto, int id)
        {
            if (orderDto == null || id <= 0)
                throw new Exception("Order DTO is required and ID must be positive");

            var existOrder = _repo.FindOrderById(id);
            if (existOrder == null)
                throw new Exception("Order not found");
            existOrder.OrderDate = orderDto.OrderDate;
            existOrder.Quantity = orderDto.Quantity;
            existOrder.TotalPrice = orderDto.TotalPrice;
            _repo.UpdateOrder(existOrder);

            return existOrder;
        }

        public Order DeleteOrder(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("id is required");
                }
               var order = _repo.DeleteOrder(id);
                return order;
            }
            catch (Exception)
            {
                throw new Exception("error to delete order");
            }
        }

    }
}