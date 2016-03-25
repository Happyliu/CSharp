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

    }
}