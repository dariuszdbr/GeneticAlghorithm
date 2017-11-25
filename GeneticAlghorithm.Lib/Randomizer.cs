using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneticAlghorithm.Lib
{
    public class Randomizer
    {
  
        // http://codeblog.jonskeet.uk/2009/11/04/revisiting-randomness/
        private static int s_seed = Environment.TickCount;

        [ThreadStatic]
        private static Random s_random;


        private static Random Random
        {
            get
            {
                if (s_random == null)
                {
                    s_random = new Random(Interlocked.Increment(ref s_seed));
                }

                return s_random;
            }
        }

        /// <summary>   
        /// Gets an integer value between minimum value (inclusive) and maximum value (exclusive).
        /// </summary>
        /// <returns>The integer.</returns>
        /// <param name="min">Minimum value (inclusive).</param>
        /// <param name="max">Maximum value (exclusive).</param>
        public int GetInt(int min, int max)
        {
            return Random.Next(min, max);
        }

        /// <summary>
        /// Gets a float value between 0.0 and 1.0.
        /// </summary>
        /// <returns>
        /// The float value.
        /// </returns>
        public float GetFloat()
        {
            return (float)Random.NextDouble();
        }

        /// <summary>
        /// Gets a double value between 0.0 and 1.0.
        /// </summary>
        /// <returns>The double value.</returns>
        public double GetDouble()
        {
            return Random.NextDouble();
        }

    }
}
