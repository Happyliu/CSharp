using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Concrete;
using CoffeeStore.Domain.Entities;
using CoffeeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore
{
    public static class DataHelper
    {
        static ICommentRepository commentRepository = new CommentRepository();
        static IProductRepository productRepository = new ProductRepository();

        public static IList<ProductDTO> ChangeProductEntityToDTO(List<Product> products)
        {
            IList<ProductDTO> list = new List<ProductDTO>();
            products.ForEach(m =>
            {
                list.Add(new ProductDTO
                {
                    ProductID = m.ProductID,
                    CategoryName = productRepository.GetCategoryName(m.CategoryID),
                    P_Name = m.P_Name,
                    P_Price = m.P_Price,
                    Label = m.Label,
                    Description = m.Description,
                    ImageData = m.ImageData,
                    ImageMimeType = m.ImageMimeType,
                    Rating = commentRepository.GetRatingByProductID(m.ProductID),
                    NoOfComments = commentRepository.GetCommentsByProductID(m.ProductID).Count()
                });
            });
            return list;
        }

        public static ProductDTO ChangeProductEntityToDTO(Product product)
        {
            return new ProductDTO
            {
                ProductID = product.ProductID,
                CategoryName = productRepository.GetCategoryName(product.CategoryID),
                P_Name = product.P_Name,
                P_Price = product.P_Price,
                Label = product.Label,
                Description = product.Description,
                ImageData = product.ImageData,
                ImageMimeType = product.ImageMimeType,
                Rating = commentRepository.GetRatingByProductID(product.ProductID),
                NoOfComments = commentRepository.GetCommentsByProductID(product.ProductID).Count()
            };
        }

        public static Comment ChangeCommentDTOToComment(CommentDTO commentDTO)
        {
            return new Comment
            {
                ProductID = commentDTO.ProductID,
                CommentID = commentDTO.CommentID,
                Rating = commentDTO.Rating,
                CommentText = commentDTO.CommentText,
                Author = commentDTO.Author,
                CommentTime = commentDTO.CommentTime
            };
        }

        public static CommentDTO ChangeCommentEntityToDTO(Comment comment)
        {
            return new CommentDTO
            {
                ProductID = comment.ProductID,
                CommentID = comment.CommentID,
                Rating = comment.Rating,
                CommentText = comment.CommentText,
                Author = comment.Author,
                CommentTime = comment.CommentTime
            };
        }

        public static IList<CommentDTO> ChangeCommentListToDTO(List<Comment> comments)
        {
            IList<CommentDTO> list = new List<CommentDTO>();
            comments.ForEach(comment =>
            {
                list.Add(new CommentDTO
                {
                    ProductID = comment.ProductID,
                    CommentID = comment.CommentID,
                    Rating = comment.Rating,
                    CommentText = comment.CommentText,
                    Author = comment.Author,
                    CommentTime = comment.CommentTime
                });
            });
            return list;
        }

        public static Order ChangeOrderDTOToOrder(OrderDTO orderDTO)
        {
            ICollection<OrderLine> list = new List<OrderLine>();
            orderDTO.Lines.ToList().ForEach(orderLineDTO =>
            {
                list.Add(new OrderLine
                {
                    Qty = orderLineDTO.Qty,
                    Price = orderLineDTO.Price,
                    ProductID = orderLineDTO.ProductID,
                    CustomerID = orderDTO.CustomerID
                });
            });
            Order order = new Order
            {
                StoreID = orderDTO.StoreID,
                CustomerID = orderDTO.CustomerID,
                OrderPrice = orderDTO.OrderPrice,
                OrderTime = orderDTO.OrderTime,
                PickUp = orderDTO.PickUp,
                PickUpTime = orderDTO.PickUpTime,
                Status = orderDTO.Status,
                Lines = list
            };
            return order;
        }

        public static OrderDTO ChangeOrderToDTO(Order order)
        {
            ICollection<OrderLineDTO> list = new List<OrderLineDTO>();
            order.Lines.ToList().ForEach(orderline =>
            {
                list.Add(new OrderLineDTO
                {
                    Qty = orderline.Qty,
                    Price = orderline.Price,
                    ProductID = orderline.ProductID,
                    CustomerID = orderline.CustomerID
                });
            });
            OrderDTO orderdto = new OrderDTO
            {
                OrderID = order.OrderID,
                StoreID = order.StoreID,
                CustomerID = order.CustomerID,
                OrderPrice = order.OrderPrice,
                OrderTime = order.OrderTime,
                PickUp = order.PickUp,
                PickUpTime = order.PickUpTime,
                Status = order.Status,
                Lines = list
            };
            return orderdto;
        }

        public static IList<OrderDTO> ChangeOrderListToDTO(List<Order> orders)
        {
            IList<OrderDTO> list = new List<OrderDTO>();
            orders.ForEach(order =>
            {
                ICollection<OrderLineDTO> orderlinelist = new List<OrderLineDTO>();
                order.Lines.ToList().ForEach(orderline =>
                {
                    orderlinelist.Add(new OrderLineDTO
                    {
                        Qty = orderline.Qty,
                        Price = orderline.Price,
                        ProductID = orderline.ProductID,
                        CustomerID = orderline.CustomerID
                    });
                });
                OrderDTO orderdto = new OrderDTO
                {
                    OrderID = order.OrderID,
                    StoreID = order.StoreID,
                    CustomerID = order.CustomerID,
                    OrderPrice = order.OrderPrice,
                    OrderTime = order.OrderTime,
                    PickUp = order.PickUp,
                    PickUpTime = order.PickUpTime,
                    Status = order.Status,
                    Lines = orderlinelist
                };
                list.Add(orderdto);
            });
            return list;
        }

    }
}