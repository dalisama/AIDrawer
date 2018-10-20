using csMatrix;
using System.Drawing;

namespace AIDrawer
{
    public static class ExtensionClass
    {
        public static Matrix ConvertToMatrix(this Bitmap image)
        {
            var mtx = new Matrix(image.Height, image.Width);
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    mtx[i, j] = image.GetPixel(j,i).G;
                }
            }
            return mtx;
        }

        public static Bitmap ConvertToBitmap(this Matrix image)
        {
            var btm = new Bitmap(image.Columns, image.Rows);
            for (int i = 0; i < image.Rows; i++)
            {
                for (int j = 0; j < image.Columns; j++)
                {
                    var val = (int)image[i, j];
                    var color = Color.FromArgb(val, val, val);
                    btm.SetPixel(j, i, color);
                }
            }
            return btm;
        }
    }
}
