using System;
using System.Drawing;



namespace MultiHtmlCraft.Core
{
    internal sealed class CHtmlDoubleBufferGraphicManagedContext : IDisposable 
    {
        
            BufferedGraphics myBuffer;


            private bool ___isBufferJustInited = true;
            public CHtmlDoubleBufferGraphicManagedContext(Graphics ___graphics, Rectangle ___DisplayRectangle)
            {
                

                this.Dispose();

                // This example assumes the existence of a form called control.
                System.Drawing.BufferedGraphicsContext currentContext;

                // Gets a reference to the current BufferedGraphicsContext
                currentContext = BufferedGraphicsManager.Current;
                // Creates a BufferedGraphics instance associated with control, and with 
                // dimensions the same size as the drawing surface of control.

                myBuffer = currentContext.Allocate(___graphics,
        ___DisplayRectangle);
                ___isBufferJustInited = true;

                //_Control.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint);

            }


            ~CHtmlDoubleBufferGraphicManagedContext()
            {
                Dispose();
            }

            public void Dispose()
            {
                if (myBuffer != null)
                {
                    myBuffer.Dispose();
                    myBuffer = null;
                }
               // _Control.Paint -= new System.Windows.Forms.PaintEventHandler(this.Paint);
            }

         

            public void Refresh()
            {
                if(___isBufferJustInited  == false && myBuffer != null)
                {
                    myBuffer.Render();
                    /*
                    Bitmap bmp = new Bitmap(_Control.Width, _Control.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                    Graphics grCon = Graphics.FromImage(bmp as Image);
                    myBuffer.Render(grCon);

                    grCon.Dispose();
                    bmp.Save("result.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                     */

                }
            }

            public Graphics Graphics
            {
                get {
                    if (myBuffer != null && myBuffer.Graphics != null)
                    {
                        return myBuffer.Graphics;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        
    }
}
