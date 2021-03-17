using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcessingTask
{
    public class ImageProcessing
    {
        public Color GetSelectedColor(int pixel)
        {
            switch (pixel)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Green;
                case 3:
                    return Color.Blue;
                default:
                    return Color.Black;
            }
        }

        public void SetMaxPixel(ref int maxPixel, int maxColor, Color color)
        {
            if (color.G > maxColor)
            {
                maxColor = color.G;
                maxPixel = 2;
            }
            if (color.B > maxColor)
            {
                maxPixel = 3;
            }
        }
        public void ToMainColors(ref Bitmap bitmap)
        {
            Color color;

            int maxColor;
            int maxPixel;

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    color = bitmap.GetPixel(j, i);
                    maxColor = color.R;
                    maxPixel = 1;

                    SetMaxPixel(ref maxPixel, maxColor, color);
                    bitmap.SetPixel(j, i, GetSelectedColor(maxPixel));
                }
            }
        }

        public async Task<Bitmap> ToMainColorsAsync(Bitmap bitmap)
        {
            Color color;

            int maxColor;
            int maxPixel;
            await Task.Run(() =>
            {
                for (int i = 0; i < bitmap.Height; i++)
                {
                    for (int j = 0; j < bitmap.Width; j++)
                    {

                        color = bitmap.GetPixel(j, i);
                        maxColor = color.R;
                        maxPixel = 1;

                        SetMaxPixel(ref maxPixel, maxColor, color);
                        bitmap.SetPixel(j, i, GetSelectedColor(maxPixel));

                    }
                }
            });

            return bitmap;

        }

    }
}

