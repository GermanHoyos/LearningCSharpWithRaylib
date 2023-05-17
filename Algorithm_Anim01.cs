using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using Rectangle = Raylib_cs.Rectangle;
using System.Threading;

namespace Examples.MyRaylibGames
{
    public static class Algorithm_Anim01
    {

        

        public static char genRandomChar()
        {
            char[] charArray = {'*','!','$'};
            int x = GetRandomValue(0,2);
            char chosenChar = charArray[x];     
            return chosenChar;
        }

        public static Raylib_cs.Color genRandomColors()
        {
            Raylib_cs.Color red = Raylib_cs.Color.RED;
            Raylib_cs.Color green = Raylib_cs.Color.GREEN;
            Raylib_cs.Color blue = Raylib_cs.Color.BLUE;
            Raylib_cs.Color[] randomColorArray = {red,green,blue};
            int randomChoice = GetRandomValue(0,2);
            return randomColorArray[randomChoice];
        }



        //do something
       public static async void waveFunction(GridCellClass i)
       {
            //1) selected cell only
            i.cellText = "*";

            PeriodicTimer customTimer = new PeriodicTimer(TimeSpan.FromSeconds(10));

            while (await customTimer.WaitForNextTickAsync())
            {
                i.cellText = "T";
            }
       }
    }
}
