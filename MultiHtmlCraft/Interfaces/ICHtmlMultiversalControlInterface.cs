using MultiHtmlCraft.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Interfaces
{
    public interface ICHtmlMultiversalControlInterface
    {
        void Invalidate();
        void Invalidate(RectangleFSpec rectFSpec);
        void DrawImage(object imagde, RectangleFSpec rectFSpec);

        bool skipWebAuthorityCheck { get; set; }
    }
}
