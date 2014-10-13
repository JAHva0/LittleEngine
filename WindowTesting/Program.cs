namespace WindowTesting
{
    using System;
    using System.Drawing;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public static class Program
    {
        public static void Main()
        {
            using (Window Win = new Window(new Size(800, 600), "Window Testing"))
            {
                Win.Run();
            }
        }
    }
    
    public class Window : GameWindow
    {
        /// <summary> Background color for the window. </summary>
        private Color clearColor;

        /// <summary> Gets or sets the background color for the window. </summary>
        /// <value> The window's background color. </value>
        public Color ClearColor
        {
            get
            {
                return this.clearColor;
            }

            set
            {
                this.clearColor = value;
                GL.ClearColor(this.clearColor);
            }
        }
        
        public Window(Size windowSize, string windowTitle)
            :base (windowSize.Width, windowSize.Height, OpenTK.Graphics.GraphicsMode.Default, windowTitle)
        {
        }

        /// <summary>
        /// Called when an OpenGL context has been created, but prior to entering the main loop.
        /// </summary>
        /// <param name="e">Not Used.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            this.ClearColor = Color.CornflowerBlue;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            this.SwapBuffers();
        }
    }
}
