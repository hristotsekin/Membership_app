using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Membership_App.Areas.Admin.Models;
using Membership_App.Entities;
using Membership_App.Models;
using Microsoft.Ajax.Utilities;

namespace Membership_App.Areas.Admin.Extensions
{
    public static class ConversionExtensions
    {
        public static IEnumerable<ProductModel> Convert(this IEnumerable<Product> products,
            UnitOfWork unitOfWork)
        {
            var productLinkText = unitOfWork.Repository<ProductLinkText>().GetAll().ToList();
            var productType = unitOfWork.Repository<ProductType>().GetAll().ToList();


            return from product in products
                select new ProductModel
                {
                    Id =  product.Id,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Title = product.Title,
                    ProductLinkTextId = product.ProductLinkTextId,
                    ProductTypeId = product.ProductTypeId,
                    ProductTypes = productType,
                    ProductLinkTexts = productLinkText,

                };
        }

        public static ProductModel Convert(this Product product,
            UnitOfWork unitOfWork)
        {
            var productText = unitOfWork.Repository<ProductLinkText>().Get(product.ProductLinkTextId);
            var productType = unitOfWork.Repository<ProductType>().Get(product.ProductTypeId);


            var model =  new ProductModel
                {
                    Id = product.Id,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Title = product.Title,
                    ProductLinkTextId = product.ProductLinkTextId,
                    ProductTypeId = product.ProductTypeId,
                    ProductTypes = new List<ProductType>(),
                    ProductLinkTexts = new List<ProductLinkText>(),

                };

            model.ProductTypes.Add(productType);
            model.ProductLinkTexts.Add(productText);

            return model;
        }
    }
}