using AutoMapper;

namespace FitnessWorld.Common.Mapping.Contracts
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
