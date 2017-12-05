using AutoMapper;

namespace FitnessWorld.Common.Mapping.Contracts
{
    interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
