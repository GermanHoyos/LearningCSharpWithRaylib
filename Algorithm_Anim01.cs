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
            char[] charArray = {'*','%','$'};
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

       public static async void waveFunction(GridCellClass i)
       {
            //get the id of the cell
            int chosenCellId = i.ID;
            int chosenCellListIndex = 0; // must be assigned or c# complains

            //get the index of where the id is
            foreach (GridCellClass x in ListOfObjects.gridList)
            {
                if (x.ID == i.ID)
                {
                    chosenCellListIndex = x.ID - 1;
                }
            }

            //1) selected cell only
            i.myCellText = "*";

            PeriodicTimer customTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));

            //must devise a way of keeping track of the row length.
            //must research wave algorithms in coding.

            while (await customTimer.WaitForNextTickAsync())
            {
                
                ListOfObjects.gridList[chosenCellListIndex - 1].myBackgroundColor = genRandomColors();
                chosenCellListIndex--;
            }



        }
    }
}
