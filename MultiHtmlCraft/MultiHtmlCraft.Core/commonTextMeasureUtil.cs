#if WINDOWS
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
#endif

namespace MultiHtmlCraft.Core
{
    public static class commonTextMeasureUtil
    {
#if WINDOWS
        /// <summary>
        /// Calculates the size (width and height) of a string when rendered with a specific font.
        /// </summary>
        public static SizeFSpec GetStringSizeFSpec(Graphics g, string text, Font font)
        {
            return GetStringSizeFSpec(g, text, font, new SizeFSpec(float.MaxValue, float.MaxValue));
        }
        public static SizeFSpec GetStringSizeFSpec(Graphics g, string text, Font font, SizeFSpec size)
        {

            if (string.IsNullOrEmpty(text)) return SizeFSpec.Empty;
            var stringFormat = new StringFormat(StringFormat.GenericTypographic);
            stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            CharacterRange[] ranges = { new CharacterRange(0, text.Length) };
            stringFormat.SetMeasurableCharacterRanges(ranges);
            Region[] regions = g.MeasureCharacterRanges(text, font, new RectangleF(0, 0, size.Width, size.Height), stringFormat);
            RectangleF rect = regions[0].GetBounds(g);
            return new SizeFSpec(rect.Width, rect.Height);

        }

        /// <summary>
        /// Calculates the size (width and height) of a string when rendered with a specific font and layout, and returns fitted characters and lines.
        /// </summary>
        public static SizeFSpec GetStringSizeFSpec(Graphics g, string text, Font font, SizeFSpec layoutSize, StringFormat stringFormat, out int charactersFitted, out int linesFitted)
        {
            if (string.IsNullOrEmpty(text))
            {
                charactersFitted = 0;
                linesFitted = 0;
                return SizeFSpec.Empty;
            }
            if (stringFormat == null)
            {
                stringFormat = new StringFormat(StringFormat.GenericTypographic);
                stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            }
            // Use MeasureCharacterRanges to simulate MeasureString's fitted chars/lines
            var ranges = new CharacterRange[] { new CharacterRange(0, text.Length) };
            stringFormat.SetMeasurableCharacterRanges(ranges);
            Region[] regions = g.MeasureCharacterRanges(text, font, new RectangleF(0, 0, layoutSize.Width, layoutSize.Height), stringFormat);
            RectangleF rect = regions[0].GetBounds(g);
            g.MeasureString(text, font, new SizeF(layoutSize.Width, layoutSize.Height), stringFormat, out charactersFitted, out linesFitted);
    
            return new SizeFSpec(rect.Width, rect.Height);
        }
#endif

    }
}
