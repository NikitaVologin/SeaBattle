using AutoMapper;
using SeaBattle.Domain.Entities;
using SeaBattle.Interaction.Mappings.Common;

namespace SeaBattle.Interaction.Data.TransportObjects
{
    public class CellInformation: IMapWith<Cell>
    {
        public int? X { get; set; }
        public int? Y { get; set; }
        public bool IsAttacked { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cell, CellInformation>()
                .ForMember(cellinfo => cellinfo.X,
                    opt => opt.MapFrom(cell => cell.X))
                .ForMember(cellinfo => cellinfo.Y,
                    opt => opt.MapFrom(cell => cell.Y))
                .ForMember(cellinfo => cellinfo.IsAttacked,
                    opt => opt.MapFrom(cell => cell.IsAttacked));
        }
    }
}