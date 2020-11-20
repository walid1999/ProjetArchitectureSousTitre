using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArchitecture
{
    class RealTime
    {

        public RealTime()
        {

        }

        // fonction qui affiche un chronometre 
        public async Task realTime()
        {
            await Task.Run(
                () =>
                {
                    Stopwatch chrono = new Stopwatch();
                    chrono.Start();
                    bool on = true;

                    while (on)
                    {
                        Console.SetCursorPosition(1, 5);
                        TimeSpan ts = chrono.Elapsed;

                        string TempsEcouler = String.Format("{0:00}:{1:00}:{2:00},{3:000}",
                          ts.Hours, ts.Minutes, ts.Seconds,
                          ts.Milliseconds / 10);

                        Console.WriteLine(TempsEcouler);

                    }
                }

                );
        }
    }
}
