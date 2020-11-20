using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetArchitecture
{
    class SousTitre
    {
        public string sousTitre;
        public int NombreSousTitre;
        public TimeSpan StartTime;
        public TimeSpan EndTime;

        public SousTitre(int nombre, string minuteur, string subtitle)
        {
            NombreSousTitre = nombre;
            sousTitre = subtitle;
            ParseTimer(minuteur);
        }

        public void ParseTimer(string minuteur)
        {
            Regex r = new Regex(@"\d{2}:\d{2}:\d{1,2},\d{3} ?--> ?\d{2}:\d{2}:\d{1,2},\d{3}");
        }

    }
}
