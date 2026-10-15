using System.Windows.Forms;

namespace WindowsFormsApp2
{
    /// <summary>
    /// Panel con doble buffer activado para que el dibujo no parpadee.
    /// (La propiedad DoubleBuffered del Panel es protegida, por eso se hereda.)
    /// </summary>
    public class clsPanelDoble : Panel
    {
        public clsPanelDoble()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}

