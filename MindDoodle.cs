using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System.Numerics;
using System.Drawing;
using Rectangle = Raylib_cs.Rectangle;

namespace Examples.MyRaylibGames
{
    public class MindDoodle
    {
        

        public static int red = 255;
        public static int green = 255;
        public static int blue = 255;
        public static int chosenString = 2;
        public static int duration;
        public bool random = false;
        Rectangle myRect = new Rectangle(255,10,9,9);
        string[] myString = {"@", "#", "*"};

        /*         Matrix
         *         [][topL]     [top]       [topR]      
         *         [][left]     [n]         [right] 
         *         [][bottomL]  [bottom]    [bottomR]
         *         
         *         topL     = n - rowLength - 1
         *         top      = n - rowLength
         *         topR     = n - rowLength + 1
         *         left     = n - 1
         *         right    = n + 1
         *         bottomL  = n + rowLength - 1
         *         bottomR  = n + rowLength + 1
         */ 

        public MindDoodle(){}

        public MindDoodle(bool random){
            this.random = random;
        }

        public void mySquare()
        {
            Raylib_cs.Color myColor =  new Raylib_cs.Color( red, green, blue, 255);

            if (duration < 2000 && random == true)
            {
                duration++;
                red = GetRandomValue(0,255);
                green = GetRandomValue(0,255);
                blue = GetRandomValue(0,255);
                chosenString = GetRandomValue(0,2);

                if (duration > 2000)
                {
                    duration = 0;
                    random = false;
                }
            }

            DrawRectangleGradientEx(myRect,BLACK,BLACK,BLACK,BLACK);
            DrawText(myString[chosenString],257,10,10,myColor);
        }

        public void DrawThis()
        {
            mySquare();
        }

    }

}
