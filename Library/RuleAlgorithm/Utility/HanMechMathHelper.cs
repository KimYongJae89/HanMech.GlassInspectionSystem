using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleAlgorithm.Utility
{
    public class HanMechMathHelper
    {
        public static float[] Derivative(float[] array)
        {
            int nSize = array.Count() - 1;
            float[] derivativeArray = new float[nSize];

            for (int i = 0; i < nSize; i++)
            {
                derivativeArray[i] = array[i + 1] - array[i];
            }
            return derivativeArray;
        }

        public static float[] Derivative(byte[] array)
        {
            int nSize = array.Count() - 1;
            float[] derivativeArray = new float[nSize];

            for (int i = 0; i < nSize; i++)
            {
                int nextValue = Convert.ToInt32(array[i + 1]);
                int value = Convert.ToInt32(array[i]);
                derivativeArray[i] = Convert.ToSingle(nextValue - value);
            }
            return derivativeArray;
        }
    }
}
