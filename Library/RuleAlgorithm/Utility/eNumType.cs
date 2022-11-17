using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleAlgorithm.Utility
{
    public enum eEdgeType
    {
        None,
        Left,
        Right,
        Top,
        Bottom,
    }

    public enum eDirection
    {
        None,
        Horizon, //가로
        Vertical, // 세로
        All,
    }
}
