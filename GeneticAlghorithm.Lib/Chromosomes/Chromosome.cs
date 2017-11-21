using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlghorithm.Lib.Chromosomes.Genes;
using GeneticAlghorithm.Lib.Problems;

namespace GeneticAlghorithm.Lib.Chromosomes
{
    public class Chromosome<T> : IChromosome<T>
    {
        private readonly Random _random = new Random();
        private readonly IProblem<T> _problem;
        public double Fitness => GetFitnes();
        public IList<Gene<T>> Genes { get; private set; }
        public Chromosome(IProblem<T> problem)
        {
            _problem = problem;
            Genes = new List<Gene<T>>(problem.ChromosomeLength);
        }

        private double GetFitnes()
        {
            return _problem.FitnessFunc(this);
        }
      
        public IChromosome<T> SetRandomValues()
        {
            Genes = Genes
                .Select(g => g.CreateNew(
                    _problem.AllowedValues
                        .ElementAt(_random.Next(0, _problem.ChromosomeLength))))
                .ToList();

            return this;
        }

        public IChromosome<T> CreateNew(IProblem<T> problem)
        {
            return new Chromosome<T>(problem);
        }

        public IChromosome<T> Clone()
        {
            //TODO Need Genes Copy
            return new Chromosome<T>(this._problem);
        }
    }

}
