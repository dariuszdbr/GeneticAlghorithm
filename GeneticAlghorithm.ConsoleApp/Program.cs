using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlghorithm.Lib;
using GeneticAlghorithm.Lib.Crossovers;
using GeneticAlghorithm.Lib.Mutations;
using GeneticAlghorithm.Lib.Problems;
using GeneticAlghorithm.Lib.Selections;

namespace GeneticAlghorithm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Run<int>();         
        }

        public static void Run<T>()
        {
            // Settings
            int populationSize = 20;
            double crossoverChance = 0.78;
            double mutationChance = 0.01;

            IProblem<T> problem;
            ICrossover<T> crossover;
            IMutation<T> mutation;
            ISelection<T> selection;
            //IGAEngine<T> solver = new GeneticAlgorithmEngine<T>(populationSize,crossoverChance,mutationChance, problem, mutation, crossover, _selection);
            

            
        }
    }
}
