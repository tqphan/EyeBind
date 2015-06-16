using System.Runtime.InteropServices;

namespace WindowsInput.Native
{
    /// <summary>
    /// Struct representing a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        public int X;
        public int Y;
    }
}
