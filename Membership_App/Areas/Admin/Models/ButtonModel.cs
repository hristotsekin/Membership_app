using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Membership_App.Areas.Admin.Models
{
    public class ButtonModel
    {
        public string Action { get; set; }
        public string Text { get; set; }
        public string Glyph { get; set; }
        public string ButtonType { get; set; }
        public int? Id { get; set; }
        public int? ItemId { get; set; }
        public int? ProductId { get; set; }
        public int? SubscriptionId { get; set; }

        public string ActionParameters {
            get
            {
                var param = new StringBuilder("?");
                if (Id != null)
                {
                    param.Append(string.Format("{0}={1}&","id",Id));
                }
                
                if (ItemId != null)
                {
                    param.Append(string.Format("{0}={1}&", "ItemId", ItemId));
                }

                if (ProductId != null)
                {
                    param.Append(string.Format("{0}={1}&", "ProductId", ProductId));
                }

                if (SubscriptionId != null)
                {
                    param.Append(string.Format("{0}={1}&", "SubscriptionId", SubscriptionId));
                }

                return param.ToString().Substring(0,param.Length-1);
            }
        }
    }
}