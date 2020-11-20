using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArchitecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lance la video
            Process.Start(@"C:\Users\Walid\Desktop\videoplayback.mp4");

            Srt s = new Srt();
            // Lecture et Analyse du fichier
            s.ReadFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\srt.srt");

            //Affichage des sous-titres en fonction du temps
            s.GetSubTitle();

            Console.Read();

        }
    }
    
}
