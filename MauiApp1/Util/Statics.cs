using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Util
{
    public class Statics
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sigma">Retorno médio</param>
        /// <param name="mean">Volatilidade média</param>
        /// <param name="initialPrice">Preço inicial</param>
        /// <param name="numDays">Número de dias</param>
        /// <returns></returns>
        public static double[] GenerateBrownianMotion(double sigma, double mean, double initialPrice, int numDays)
        {
            Random rand = new();
            double[] prices = new double[numDays];
            prices[0] = initialPrice;

            for (int i = 1; i < numDays; i++)
            {
                double u1 = 1.0 - rand.NextDouble();
                double u2 = 1.0 - rand.NextDouble();
                double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

                double retornoDiario = (mean / 100) + (sigma / 100) * z;
                prices[i] = prices[i - 1] * Math.Exp(retornoDiario);
            }
            return prices;
        }

        public void GeneretePrices()
        {

            Random random = new Random();
            double t = 0.01;
            double mu = 0.5;
            int nsteps = 1000;
            Dictionary<string, List<double>> simulationData = new Dictionary<string, List<double>>();

            for (int i = 0; i < 5; i++)
            {
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                for (int j = 0; j < nsteps; j++)
                {
                    double step = mu * 0.01 + random.NextDouble() * Math.Sqrt(t);
                    y.Add(step);
                    if (j == 0)
                    {
                        x.Add(0);
                    }
                    else
                    {
                        x.Add(t * j);
                    }
                }
                simulationData.Add("y" + i, y);
                simulationData["x"] = x;
            }

            List<string> yCols = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                yCols.Add("y" + i);
            }


        }



    }
}
