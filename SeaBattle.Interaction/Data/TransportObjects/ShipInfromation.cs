using AutoMapper;
using SeaBattle.Domain.Entities;
using SeaBattle.Interaction.Mappings.Common;

namespace SeaBattle.Interaction.Data.TransportObjects
{
    public class ShipInformation: IMapWith<Ship>
    {
        public int Id { get; set; }

        public List<CellInformation> Cells { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Ship, ShipInformation>()
                .ForMember(shipinfo => shipinfo.Id,
                    opt => opt.MapFrom(ship => ship.Id))
                .ForMember(shipinfo => shipinfo.Cells,
                    opt => opt.MapFrom(ship => ship.Cells));
        }
    }
}