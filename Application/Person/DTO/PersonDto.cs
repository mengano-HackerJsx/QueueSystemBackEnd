using Application.Common.DTO;
using Domain.Enums;

namespace Application.Person.DTO
{
    public class PersonDto : BaseEntityDto //: BaseEntityDto, ICommonPersonAttributes
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }
}
