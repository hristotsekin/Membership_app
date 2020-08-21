using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Membership_App.Entities;

namespace Membership_App.Areas.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [DisplayName("Image Url")]
        [MaxLength(1024)]
        public string ImageUrl { get; set; }

        public int ProductLinkTextId { get; set; }

        public int ProductTypeId { get; set; }

        public ICollection<ProductLinkText> ProductLinkTexts { get; set; }

        public ICollection<ProductType> ProductTypes { get; set; }

        [DisplayName("Type")]
        public string ProductType
        {
            get
            {
                return ProductTypes == null || ProductTypes.Count.Equals(0) || ProductLinkTexts.Where(prod => prod.Id.Equals(ProductLinkTextId)).Count() == 0
                    ? String.Empty
                    : ProductTypes.First(prod => prod.Id.Equals(ProductTypeId)).Title;
            }
        }

        [DisplayName("Link Text")]
        public string ProductLinkText
        {
            get
            {
                return ProductLinkTexts == null || ProductLinkTexts.Count.Equals(0) || ProductLinkTexts.Where(prod => prod.Id.Equals(ProductLinkTextId)).Count() == 0
                    ? String.Empty
                    : ProductLinkTexts.First(prod => prod.Id.Equals(ProductLinkTextId)).Title;
            }
        }

    }
}