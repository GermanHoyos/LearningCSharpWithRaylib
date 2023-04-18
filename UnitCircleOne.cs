using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace Examples.MyRaylibGames
{
    public class UnitCircleOne
    {

        public UnitCircleOne()
        {
            //instantiate with no parameters
        }

        public void DrawThis()
        {
           DrawCircle(30, 120, 35, DARKBLUE);
        }

    }
}
