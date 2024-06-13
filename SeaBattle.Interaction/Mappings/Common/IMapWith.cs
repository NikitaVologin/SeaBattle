using AutoMapper;

namespace SeaBattle.Interaction.Mappings.Common
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
