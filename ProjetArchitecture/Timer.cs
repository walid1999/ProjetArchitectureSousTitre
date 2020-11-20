using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetArchitecture
{
    class Timer
    {
        public string sousTitre;
        public int NombreSousTitre;
        public TimeSpan Start;
        public TimeSpan End;

        public Timer(int nombre, string minuteur, string soustitre)
        {
            NombreSousTitre = nombre;
            sousTitre = soustitre;
            ParseTime(minuteur);
        }

        private TimeSpan GetTime(string minuteur)
        {
            char[] charsplitOn = { ':', ',' };
            string[] splitMinuteur = minuteur.Split(charsplitOn);

            return new TimeSpan(0, Int32.Parse(splitMinuteur[0]), Int32.Parse(splitMinuteur[1]), Int32.Parse(splitMinuteur[2]), Int32.Parse(splitMinuteur[3]));
        }

        //analyse le temps où le sous titre dois etre affiché puis enlevé et qui seront stocké dans les variables Start et End
        public void ParseTime(string minuteur)
        {
            Regex r = new Regex(@"\d{2}:\d{2}:\d{2},\d{3} ?--> ?\d{2}:\d{2}:\d{2},\d{3}");

            if (r.IsMatch(minuteur))
            {
                string[] splitOn = { "-->" };
                string[] timerSplit = minuteur.Split(splitOn, StringSplitOptions.None);
                Start = GetTime(timerSplit[0]);
                End = GetTime(timerSplit[1]);
            }
        }

        // Le moment où le sous-titre s'affiche.
        public async Task TimeToAdd()
        {
            await Task.Delay(Start);
        }

        // Le temps que pendant lequel le sous-titre doit s'afficher.
        public async Task TimeToDisplay()
        {
            await Task.Delay(End - Start);
        }

        // Le moment où le sous-titre s'enleve.
        public async Task TimeToRemove()
        {
            await Task.Delay(End);
        }


        public async Task AddSubTitle()
        {
            await TimeToAdd();

            // Permet de bloquer l'affichage pour pas que le texte défile.
            Console.SetCursorPosition(2, 1);

            Console.WriteLine(sousTitre);

            await TimeToDisplay();
            Console.Clear();
        }


    }
}
