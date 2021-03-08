using System;
using System.Collections.Generic;
using System.Text;

namespace KNU.IS.ClassScheduling.Logic.Models.Genetic
{
    public class Chromosome<T>
    {
        public Chromosome(IEnumerable<T> genes, double fitness)
        {
            Genes = genes;
            Fitness = fitness;
        }

        public IEnumerable<T> Genes { get; }
        public double Fitness { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gene in Genes)
            {
                sb.Append(gene.ToString());
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
