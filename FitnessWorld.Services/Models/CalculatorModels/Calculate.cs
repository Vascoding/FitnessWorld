using AutoMapper;
using FitnessWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWorld.Services.Models.CalculatorModels
{
    public class NameMeJohnAction : IMappingAction<Food, CalculatorServiceModel>
    {
        public void Process(Food source, CalculatorServiceModel destination)
        {
            destination.Calc();
        }
    }
}
