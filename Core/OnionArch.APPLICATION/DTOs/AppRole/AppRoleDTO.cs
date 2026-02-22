using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.APPLICATION.DTOs.AppRole
{
    public class AppRoleDTO:BaseDTO
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
