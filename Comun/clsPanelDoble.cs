using System.Windows.Forms;

namespace WindowsFormsApp2.Comun
{
    // Panel con doble buffer para evitar parpadeo
    public class clsPanelDoble : Panel
    {
        public clsPanelDoble()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}
