using System.Collections.Generic;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Crossovers
{
    public interface ICrossover<T>
    {
        IPopulation<T> Cross(double crossoverChance, IPopulation<T> population);
    }
}