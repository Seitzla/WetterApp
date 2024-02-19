using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Weather_App
{

    public class FotoKlasse
    {
        private static int lastSelectedIndex = 2;
       
        public string SelectImage(string input)
        {
            switch (input)
            {
                case "Rain":
                    return SelectImageRain();
                case "Clouds":
                    return SelectImageClouds();
                case "Snow":
                    return SelectImageSnow();
                case "Thunderstorm":
                    return SelectImageThunderstorm();
                case "Drizzle":
                    return SelectImageDrizzle();
                case "Atmosphere":
                    return SelectImageAtmosphere();
                case "Clear":
                    return SelectImageClear();
                default:
                    return string.Empty;
            }
        }

        private string SelectImageRain()
        {       
            string[] images = { "Bilder/regen1.jpg", "Bilder/regen2.jpg", "Bilder/regen3.jpg" };
            lastSelectedIndex++;
            if (lastSelectedIndex == 3)
            {
                lastSelectedIndex = 0;
            }
            return images[lastSelectedIndex];
        }
        private string SelectImageClouds()
        {
            string[] images = { "Bilder/Wolken1.jpg", "Bilder/Wolken2.jpg", "Bilder/Wolken3.jpg" };
            lastSelectedIndex++;
            if (lastSelectedIndex == 3)
            {
                lastSelectedIndex = 0;
            }
            return images[lastSelectedIndex];
        }
        private string SelectImageSnow()
        {
            string[] images = { "Bilder/Schnee1.jpg", "Bilder/Schnee2.jpg", "Bilder/Schnee3.jpg" };
            lastSelectedIndex++;
            if (lastSelectedIndex == 3)
            {
                lastSelectedIndex = 0;
            }
            return images[lastSelectedIndex];
        }
        private string SelectImageThunderstorm()
        {
            string[] images = { "Bilder/Blitze1.jpg", "Bilder/Blitze2.jpg", "Bilder/Blitze3.jpg" };
            lastSelectedIndex++;
            if (lastSelectedIndex == 3)
            {
                lastSelectedIndex = 0;
            }
            return images[lastSelectedIndex];
        }
        private string SelectImageDrizzle()
        {
            string[] images = { "Bilder/Nieselregen1.jpg", "Bilder/Nieselregen2.jpg", "Bilder/Nieselregen3.jpg" };
            lastSelectedIndex++;
            if (lastSelectedIndex == 3)
            {
                lastSelectedIndex = 0;
            }
            return images[lastSelectedIndex];
        }
        private string SelectImageAtmosphere()
        {
            string[] images = { "Bilder/Nebel1.jpg", "Bilder/Nebel2.jpg", "Bilder/Nebel3.jpg" };
            lastSelectedIndex++;
            if (lastSelectedIndex == 3)
            {
                lastSelectedIndex = 0;
            }
            return images[lastSelectedIndex];
        }
        private string SelectImageClear()
        {
            string[] images = { "Bilder/Sonnig1.jpg", "Bilder/Sonnig2.jpg", "Bilder/Sonnig3.jpg" };
            lastSelectedIndex++;
            if (lastSelectedIndex == 3)
            {
                lastSelectedIndex = 0;
            }
            return images[lastSelectedIndex];
        }
    }
}
