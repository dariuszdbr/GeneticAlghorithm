using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlghorithm.Lib
{
    public static class RandomizerProvider
    {
        static RandomizerProvider()
        {
            Current = new Randomizer();
        }
        public static Randomizer Current { get; set; }
    }
}
