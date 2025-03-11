using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.APPLICATION.DTOs.OrderDetails
{
    public class OrderDetailDTO:BaseDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
    }
}
