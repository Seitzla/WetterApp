using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App
{
    internal class Zeitsprünge
    {
        public static int GetJumpCount()
        {
            // Aktuelle Uhrzeit auslesen
            DateTime now = DateTime.Now;

            // Zielzeit: Nächster Tag um 12 Uhr
            DateTime targetTime = now.AddDays(1).Date + new TimeSpan(12, 0, 0);

            // Differenz zwischen der aktuellen Uhrzeit und der Zielzeit berechnen
            TimeSpan difference = targetTime - now;

            // Anzahl der 3-Stunden-Sprünge berechnen
            int jumpCount = (int)(difference.TotalHours / 3);

            return jumpCount;
        }
    }
}
