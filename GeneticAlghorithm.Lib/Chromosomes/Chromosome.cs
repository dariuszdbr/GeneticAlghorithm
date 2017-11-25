using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlghorithm.Lib.Chromosomes.Genes;
using GeneticAlghorithm.Lib.Problems;

namespace GeneticAlghorithm.Lib.Chromosomes
{
    public class Chromosome<T> : IChromosome<T>
    {
        private readonly IProblem<T> _problem;
        public double Fitness => GetFitnes();
        public Gene[] Genes { get; private set; }
        
        public Chromosome(IProblem<T> problem)
        {
            _problem = problem;
            Genes = new Gene[problem.ChromosomeLength];
        }

        private double GetFitnes()
        {
            return _problem.FitnessFunc(this);
        }
      
        public IChromosome<T> SetRandomValues()
        {
            for (int i = 0; i < _problem.ChromosomeLength; i++)
            {
                Genes[i] = new Gene (_problem.AllowedValues
                    .ElementAt(RandomizerProvider.Current.GetInt(0, _problem.AllowedValues.Length)));
            } 
            
            return this;
        }

        public void ReplaceGenes(int startIndex, Gene[] genes)
        {
            if (genes == null) throw new ArgumentNullException(nameof(genes));
            var length = genes.Length - startIndex;
            Array.Copy(genes, startIndex, this.Genes, startIndex, length);           
        }

        public void ReplaceGene(int index, Gene gene)
        {
            this.Genes[index] = gene ?? throw new ArgumentNullException(nameof(gene));
        }

        public IChromosome<T> CreateNew(IProblem<T> problem)
        {
            if (problem == null) throw new ArgumentNullException(nameof(problem));
            return new Chromosome<T>(problem);
        }

        public IChromosome<T> Clone()
        {
            CopyGenes(this.Genes, out var newGenes);
            return new Chromosome<T>(this._problem){Genes = newGenes};
        }

        private void CopyGenes(Gene[] fromGenes, out Gene[] toGenes)
        {
            if (fromGenes == null) throw new ArgumentNullException(nameof(fromGenes));
            
            toGenes = new Gene[fromGenes.Length];
            Array.Copy(fromGenes, toGenes, fromGenes.Length);
        }

        public override string ToString()
        {
            return string.Join(" ", Genes.Select(g => g.Value)) + $" Fitness: {Fitness}";
        }
    }

}
