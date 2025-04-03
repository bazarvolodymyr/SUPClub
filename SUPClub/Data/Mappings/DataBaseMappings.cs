using AutoMapper;
using SUPClub.Data.Entities;
using SUPClub.Models;

namespace SUPClub.Data.Mappings
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings()
        {
            CreateMap<HireCategoryEntity, HireCategory>().ReverseMap();
            CreateMap<HireSubCategoryEntity, HireSubCategory>().ReverseMap();
        }
    }
}
