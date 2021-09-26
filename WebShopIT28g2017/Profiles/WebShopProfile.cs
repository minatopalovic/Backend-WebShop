using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIT28g2017.Entities;
using WebShopIT28g2017.Models;

namespace WebShopIT28g2017.Profiles
{
    public class WebShopProfile : Profile
    {

        public WebShopProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<Wardrobe, WardrobeDto>()
                .ForMember(
                dest => dest.Category,
                opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(
                dest => dest.Material,
                opt => opt.MapFrom(src => src.Material.MaterialName))
                .ForMember(
                dest => dest.Model,
                opt => opt.MapFrom(src => src.Model.ModelName))
                .ForMember(
                dest => dest.Supplier,
                opt => opt.MapFrom(src => src.Supplier.SupplierName));


            CreateMap<User, UserDto>()
                .ForMember(
                dest => dest.Rolee,
                opt => opt.MapFrom(src => src.RoleeNavigation.RoleName));

            CreateMap<Order, OrderDto>()
                .ForMember(
                dest => dest.User,
                opt => opt.MapFrom(src => $"{src.User.UserFirstName} {src.User.UserLastName}"));

            CreateMap<User, Principal>()
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.UserUserName))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => s.UserPassword))
                .ForMember(d => d.Rolee, opt => opt.MapFrom(s => s.Rolee))
                .ForMember(d => d.Salt, opt => opt.MapFrom(s => s.Salt));

            CreateMap<UserCreationDto, User>();

            CreateMap<OrderWardrobe, OWDto>()
                .ForMember(d => d.User, opt => 
                opt.MapFrom(s => $"{s.OrderrNavigation.User.UserFirstName} {s.OrderrNavigation.User.UserLastName}"))
                .ForMember(d => d.OrderDate, opt =>
                opt.MapFrom(s => s.OrderrNavigation.OrderDate))
                .ForMember(d => d.PaymentMethod, opt =>
                opt.MapFrom(s => s.OrderrNavigation.PaymentMethod))
                .ForMember(d => d.TotalPrice, opt =>
                opt.MapFrom(s => s.OrderrNavigation.TotalPrice))
                .ForMember(d => d.Confirmed, opt =>
                opt.MapFrom(s => s.OrderrNavigation.Confirmed))
                .ForMember(d => d.Model, opt =>
                opt.MapFrom(s => s.WardrobeNavigation.Model.ModelName))
                .ForMember(d => d.Category, opt =>
                opt.MapFrom(s => s.WardrobeNavigation.Category.CategoryName))
                .ForMember(d => d.Material, opt =>
                opt.MapFrom(s => s.WardrobeNavigation.Material.MaterialName))
                .ForMember(d => d.WardrobeColor, opt =>
                opt.MapFrom(s => s.WardrobeNavigation.WardrobeColor))
                .ForMember(d => d.WardrobeSize, opt =>
                opt.MapFrom(s => s.WardrobeNavigation.WardrobeSize))
                .ForMember(d => d.WardrobePrice, opt =>
                opt.MapFrom(s => s.WardrobeNavigation.WardrobePrice))
                .ForMember(d => d.WardrobeDescription, opt =>
                opt.MapFrom(s => s.WardrobeNavigation.WardrobeDescription))
                .ForMember(d => d.WardrobePicture, opt =>
                opt.MapFrom(s => s.WardrobeNavigation.WardrobePicture))
                .ForMember(d => d.WardrobeBrand, opt =>
                opt.MapFrom(s => s.WardrobeNavigation.WardrobeBrand))
                .ForMember(d => d.Quantity, opt =>
                opt.MapFrom(s => s.Quantity));

            CreateMap<Supplier, SupplierDto>();

            CreateMap<Role, RoleDto>();

            CreateMap<Material, MaterialDto>();

            CreateMap<Model, ModelDto>();

            CreateMap<WardrobeCreationDto, Wardrobe>();

            CreateMap<OrderCreationDto, Order>();

            CreateMap<OrderWardrobeCreationDto, OrderWardrobe>()
                .ForMember(d => d.Orderr, opt =>
                opt.MapFrom(s => s.orderId))
                .ForMember(d => d.Wardrobe, opt =>
                opt.MapFrom(s => s.wardrobeId))
                .ForMember(d => d.Quantity, opt =>
                opt.MapFrom(s => s.quantity));

            CreateMap<WardrobeUpdateDto, Wardrobe>();


        }
    }
}
