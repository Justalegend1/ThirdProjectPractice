using System;
using System.Drawing;
using PluginInterface;

namespace Black_White_Filter
{
    [Version(1, 0)]
    public class GrayFilters : IPlugin
    {
        public string Name
        {
            get
            {
                return "Черно-белый";
            }
        }

        public string Author
        {
            get
            {
                return "Me";
            }
        }

        public void Transform(Bitmap bitmap)
        {
            for (int j = 0; j < bitmap.Height; j++)
                for (int i = 0; i < bitmap.Width; i++)
                {
                   
                    UInt32 pixel = (UInt32)(bitmap.GetPixel(i, j).ToArgb());
                    float R = (float)((pixel & 0x00FF0000) >> 16); 
                    float G = (float)((pixel & 0x0000FF00) >> 8); 
                    float B = (float)(pixel & 0x000000FF); 
                    R = G = B = (R + G + B) / 3.0f;
                    UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                    bitmap.SetPixel(i, j, Color.FromArgb((int)newPixel));
                }
        }

    }
}
