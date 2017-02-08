using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PcXecucte_3._0.Classes
{
    class BM_Mouse
    {
        //====================================================================
        // Atributos estaticos
        //====================================================================
        private static BM_Mouse instancia;
        //====================================================================

        //====================================================================
        // Get Instance
        //====================================================================
        public static BM_Mouse getInstance()
        {
            if (instancia == null)
                instancia = new BM_Mouse();
            return instancia;
        }
        //====================================================================

        //====================================================================
        //Metodo construtor
        //====================================================================
        private BM_Mouse()
        {

        }
        //====================================================================

        //====================================================================
        // Atributos
        //====================================================================
        [Flags]
        public enum MouseEventFlags
        {
            Null = 0,
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }
        //====================================================================

        //====================================================================
        // Importar classe de controle de posição do mouse
        //====================================================================
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);
        //====================================================================

        //====================================================================
        // Importar classe de eventos do mouse
        //====================================================================
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        //====================================================================

        //====================================================================
        // Obter posição do mouse
        //====================================================================
        public int GetCursorPosX()
        {
            return Cursor.Position.X;
        }
        public int GetCursorPosY()
        {
            return Cursor.Position.Y;
        }
        //====================================================================

        //====================================================================
        // Comandos de botões do mouse virtual
        //====================================================================
        public void EventCommandMouse(BM_Comando.Mouse _mouse)
        {
            if (_mouse.Botao.BotaoEsquerdo)
                SetMouseEvent(MouseEventFlags.LeftDown | MouseEventFlags.RightUp, _mouse.CoordenadaX, _mouse.CoordenadaY);
            if (_mouse.Botao.BotaoCentral)
                SetMouseEvent(MouseEventFlags.MiddleDown | MouseEventFlags.MiddleUp, _mouse.CoordenadaX, _mouse.CoordenadaY);
            if(_mouse.Botao.BotaoDireito)
                SetMouseEvent(MouseEventFlags.RightDown | MouseEventFlags.RightUp, _mouse.CoordenadaX, _mouse.CoordenadaY);
            SetMouseEvent(MouseEventFlags.Null, _mouse.CoordenadaX, _mouse.CoordenadaY);
        }
        //====================================================================

        //====================================================================
        // Evento do mouse
        //====================================================================
        private void SetMouseEvent(MouseEventFlags _Event = MouseEventFlags.Null, int X = 0, int Y = 0)
        {
            SetCursorPos(X, Y);
            if (_Event != MouseEventFlags.Null)
                mouse_event((int)_Event, X, Y, 0, 0);
        }
        //====================================================================

    }
}
