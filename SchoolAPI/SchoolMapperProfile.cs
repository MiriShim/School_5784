using AutoMapper;
using DTO;
using SchoolDAL.Model;

namespace SchoolAPI
{
   

    public class SchoolMapperProfile : Profile
    {
        public SchoolMapperProfile()
        {
             
            CreateMap<User , UserDTO >()
                .ForMember(a=>a.PasswordDTO  ,m=>m.MapFrom(p=>p.PasswordHash ))
                .ReverseMap()
                .ForMember(a => a.PasswordHash, m => m.MapFrom(p => p.PasswordDTO))
                ;

            CreateMap<UserGroup , GroupDTO >()
                .ForMember(a=>a.Month , m=>m.MapFrom(p=>p.CreatedAt.Value.Month  ))
                .ReverseMap ()
                .ForMember(a => a.CreatedAt , m => m.MapFrom(p => DateTime.Today ));
           
            
        }
    }
}
