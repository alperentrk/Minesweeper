using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme3
{
    public class Scoreboard
    {



        public int skorHesapla(int bulunanMayinlar, int gecenSure)
        {
            if (bulunanMayinlar == 0 || gecenSure == 0)
            {
                return 0;
            }
            else
            {
                return (int)((bulunanMayinlar / (double)gecenSure) * 1000);
            }
        }
    }
}
