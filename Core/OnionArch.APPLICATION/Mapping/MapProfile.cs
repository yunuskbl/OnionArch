using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArch.APPLICATION.DTOs.AppRole;
using OnionArch.APPLICATION.DTOs.AppUser;
using OnionArch.APPLICATION.DTOs.AppUserRole;
using OnionArch.APPLICATION.DTOs.Categories;
using OnionArch.APPLICATION.DTOs.OrderDetails;
using OnionArch.APPLICATION.DTOs.Orders;
using OnionArch.APPLICATION.DTOs.Products;
using OnionArch.APPLICATION.DTOs.Profiles;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.APPLICATION.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            #region ProductMapping
            CreateMap<Product ,ProductsDTO>().ReverseMap();
            #endregion
            #region CategoryMapping
            CreateMap<Category,CategoryDTO>().ReverseMap();
            #endregion
            #region OrderMapping
            CreateMap<Order,OrdersDTO>().ReverseMap();
            #endregion
            #region OrderDetailMapping
            CreateMap<OrderDetail,OrderDetailsDTO>().ReverseMap();
            #endregion
            #region AppRoleMapping
            CreateMap<AppRole,AppRoleDTO>().ReverseMap();
            #endregion
            #region AppUserMapping
            CreateMap<AppUser,AppUserDTO>().ReverseMap();
            #endregion
            #region AppUserRoleMapping
            CreateMap<AppUserRole,AppUserRoleDTO>().ReverseMap();
            #endregion
            #region AppUserProfileMapping
            CreateMap<AppUserProfile, AppUserProfilesDTO>().ReverseMap();
            #endregion
        }

    }
}
