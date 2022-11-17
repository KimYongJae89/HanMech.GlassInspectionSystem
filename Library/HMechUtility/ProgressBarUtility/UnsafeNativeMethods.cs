using System;
using System.Runtime.InteropServices;
using System.Security;

namespace HMechUtility.ProgressBarUtility
{

    [SuppressUnmanagedCodeSecurity]
    internal static class UnsafeNativeMethods
    {

        /* Prepares the specified window for painting and fills 
        a PAINTSTRUCT structure with information about the painting */
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = false)]
        internal static extern IntPtr BeginPaint(HandleRef hWnd, [In][Out] ref NativeMethods.PAINTSTRUCT lpPaint);

        /* Marks the end of painting in the specified window. 
        This function is required for each call to the BeginPaint 
        function, but only after painting is complete. */
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = false)]
        internal static extern bool EndPaint(HandleRef hWnd, ref NativeMethods.PAINTSTRUCT lpPaint);

    }

}
