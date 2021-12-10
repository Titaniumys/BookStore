using BookStore.Data.interfaces;
using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopBook shopBook;

        public OrdersRepository(AppDBContent appDBContent, ShopBook shopBook)
        {
            this.appDBContent = appDBContent;
            this.shopBook = shopBook;

        }

        //3
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopBook.listShopItem;
          
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    BookID = el.book.id,
                    orderID = order.id,
                    price = el.book.price
                };
                appDBContent.OrderDetail.Add(orderDetail);                
            }
            appDBContent.SaveChanges();
        }
    } 
}
