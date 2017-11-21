using GeneticAlghorithm.Lib.Chromosomes;

namespace GeneticAlghorithm.Lib.Problems
{
    public interface IProblem<T>
    {
        int ChromosomeLength { get; set; }

        T[] AllowedValues { get; set; }

        double FitnessFunc(IChromosome<T> chromosome);
    }
}
