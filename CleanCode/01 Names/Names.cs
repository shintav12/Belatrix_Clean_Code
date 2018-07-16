using System.Drawing;

namespace CleanCode.Names
{
    public class GraphicEditor
    {
        public Bitmap BitmapDrawer(string fileName)
        {
            var bitmap = new Bitmap(fileName);
            var image = Graphics.FromImage(bitmap);
            image.DrawString("a", SystemFonts.DefaultFont, SystemBrushes.Desktop, new PointF(0, 0));
            image.DrawString("b", SystemFonts.DefaultFont, SystemBrushes.Desktop, new PointF(0, 20));
            image.DrawString("c", SystemFonts.DefaultFont, SystemBrushes.Desktop, new PointF(0, 30));
            return bitmap;
        }
    }
}
