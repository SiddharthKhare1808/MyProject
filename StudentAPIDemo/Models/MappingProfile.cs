using AutoMapper;

namespace StudentAPIDemo.Models
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Student, StudentMini>();
        }
    }
}
