using System;
using System.Linq;
using GeneticAlghorithm.Lib.Chromosomes;

namespace GeneticAlghorithm.Lib.Problems
{
    public class MaximumOfQuadraticFuncionInRangeProblem : IProblem<int>
    {
        public int ChromosomeLength { get; set; } = 5;
        public int[] AllowedValues { get; set; } = {0, 1};
        public double FitnessFunc(IChromosome<int> chromosome)
        {
            int X = Convert.ToInt32(
                string.Join("", chromosome.Genes.Select(g => g.Value.ToString())), 2);

            if (X == 0) return 1 / double.MaxValue;

            const double A = -10.0;
            const double B = 50.0;
            const double C = 45.0;

            //f(x) = ax^2 + b * lnx - c * sqrt(x^2 + 1);
            return Math.Pow(X, 2.0) * A + B * Math.Log(X) + C * Math.Sqrt(Math.Pow(X, 2.0) + 1);

        }

    }
}