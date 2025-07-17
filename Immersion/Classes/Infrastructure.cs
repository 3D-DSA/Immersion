using System.Windows.Forms;

namespace Immersion.Classes
{
    internal class Infrastructure
    {
        internal static List<Screen> GetScreenList()
        {
            return Screen.AllScreens.ToList();
        }
    }
}