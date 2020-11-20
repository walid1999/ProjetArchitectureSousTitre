using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArchitecture
{
    class Srt
    {
        public enum StatusLine { NumeroLigne, TimeLigne, LigneSousTitre, LigneVide };
        public List<string> ToutesLesLignesFichier;
        public List<Timer> TousLesSousTitre;
       

        public Srt()
        {
        }

        // Lecture du fichhier srt
        public void ReadFile(string chemin)
        {

            using (StreamReader sr = new StreamReader(chemin))
            {
                ToutesLesLignesFichier = new List<string>();

                string ligne;

                while ((ligne = sr.ReadLine()) != null)
                    ToutesLesLignesFichier.Add(ligne);

                ParseFile();

            }

        }

        // Analyse du fichier srt
        private void ParseFile()
        {
            int nbSub = -1;
            string Timer = "";
            string Subs = "";
            StatusLine statusL = StatusLine.NumeroLigne;
            TousLesSousTitre = new List<Timer>();

            foreach (string line in ToutesLesLignesFichier)
            {
                if (line == "")
                {
                    statusL = StatusLine.LigneVide;
                }

                switch (statusL)
                {
                    case StatusLine.NumeroLigne:
                        nbSub = Int32.Parse(line);
                        statusL++;
                        break;
                    case StatusLine.TimeLigne:
                        Timer = line;
                        statusL++;
                        break;
                    case StatusLine.LigneSousTitre:
                        Subs += line + "\n";
                        break;
                    case StatusLine.LigneVide:
                        Timer sub = new Timer(nbSub, Timer, Subs);
                        if (!TousLesSousTitre.Contains(sub))
                            TousLesSousTitre.Add(sub);
                        statusL = StatusLine.NumeroLigne;
                        Subs = "";
                        break;
                }
            }

            
        }

        // affichage des sous-titres 
        public void GetSubTitle()
        {
            // RealTime T = new RealTime();

            // Task t = T.realTime();

            foreach (Timer sub in TousLesSousTitre)
            {

                Task r = sub.AddSubTitle();
            }
        }
    }
}
