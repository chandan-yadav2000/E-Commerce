using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forms.Models
{
    public partial class PaymentGateway
    {
        public int PaymentId { get; set; }
        public Nullable<int> Amount { get; set; }
      
        public virtual tbl_Mvc User { get; set; }
        
    }
}