using System.Runtime.InteropServices;

namespace MechAI.Model
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct BboxContainer
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = MECHAIForHanmech.MaxObjects)]
        internal BboxT[] candidates;
    }
}
