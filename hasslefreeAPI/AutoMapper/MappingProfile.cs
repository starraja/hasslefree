using AutoMapper;
using hasslefreeAPI.Entities;
//using hasslefreeAPI.Entities;
using hasslefreeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<UserDto, UserMaster>();
            //CreateMap<UserMaster, UserDto>();
            //CreateMap<CreateUserDto, UserMaster>();
            CreateMap<LeadDto, Leads>();
            CreateMap<Leads, LeadDto>();
            CreateMap<ActivitiesDto, Activities>();
            CreateMap<Activities, ActivitiesDto>();
            CreateMap<NotesDto, Notes>();
            CreateMap<Notes, NotesDto>();
            CreateMap<ContactsDto, Contacts>();
            CreateMap<Contacts, ContactsDto>();
            CreateMap<ProductListDto, ProductList>();
            CreateMap<ProductList, ProductListDto>();
            //CreateMap<LeadDto, ProductList>()
            //    .ForMember(productlist => productlist, lead => lead.MapFrom(q => q.ProductList));
            //CreateMap<ProductList, LeadDto>()
            //   .ForMember( lead => lead.MapFrom(q => q.ProductList), productlist => productlist);
        }
    }
}
