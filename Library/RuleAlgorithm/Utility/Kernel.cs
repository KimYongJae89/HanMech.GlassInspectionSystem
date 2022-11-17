using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleAlgorithm.Utility
{
    public static class Kernel
    {
        public static float[] HorizonEdge = {
                                            -0.2f, -0.2f, -0.2f,
                                               0.1f,  0.0f,  0.1f,
                                               0.2f,  0.2f,  0.2f};

        public static float[] VerticalEdge = {
                                                -0.2f, 0.0f, 0.2f,
                                               -0.2f, 0.0f, 0.2f,
                                               -0.2f, 0.0f, 0.2f};
    }
}
