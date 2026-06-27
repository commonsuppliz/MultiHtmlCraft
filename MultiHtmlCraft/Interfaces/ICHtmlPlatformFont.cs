using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MultiHtmlCraft.Interfaces
{
    public interface ICHtmlPlatformFont : IDisposable
    {
        float GetHeight();
        float Height { get; }
        System.Drawing.SizeF MeasureString(string text, float maxWidth, out int charsFitted, out int linesFitted);
    }
}
