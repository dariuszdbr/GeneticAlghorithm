using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using GeneticAlghorithm.Lib.Chromosomes;
using GeneticAlghorithm.Lib.Populations;

namespace GeneticAlghorithm.Lib.Selections
{
    public interface ISelection<T>
    {
        IPopulation<T> SelectChromosomes(IPopulation<T> population);
    }
}