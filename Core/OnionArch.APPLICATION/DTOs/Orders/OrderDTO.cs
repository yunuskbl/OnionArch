using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.APPLICATION.DTOs.Orders
{
    public class OrderDTO:BaseDTO
    {
        public string ShippedAddress { get; set; }
        public int? AppUserID { get; set; }
    }
}
