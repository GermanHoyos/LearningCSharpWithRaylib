using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Numerics;
using System.Drawing;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using Rectangle = Raylib_cs.Rectangle;

namespace Examples.MyRaylibGames
{
    public class GridCellClass
    {
        //unique id for each instatiated object
        public static int thisID = 1;
        public static int thisX = 175;
        public static int thisY = 5;
        public int ID { get; set; }
        public int myX { get; set; }
        public int myY { get; set; }
        //values to manipulate that pertain to "this" object
        public int red = 255;
        public int green = 255;
        public int blue = 255;
        public int chosenString = 2;
        public int duration;
        public bool random = false;
        public Rectangle myRect;
        public string testText = "";
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
         *         center   = n
         *         right    = n + 1
         *         bottomL  = n + rowLength - 1
         *         bottomR  = n + rowLength + 1
         */

        //animation sequances

        //Wave initial
        public bool WAVE = false;
        float waveX = 100;
        float waveY = 10;

        public Vector2 waveXY;


        public GridCellClass(){}

        public GridCellClass(bool random) {
            this.random = random;
            //build grid with placement of squares
            ID = thisID++;
            thisX += 20;
            //screenwidth - this objs width
            if (thisX > 800 - 20) 
            {
                thisY += 20;
                thisX = 195;
            }
            myX = thisX;
            myY = thisY;
            myRect = new Rectangle(myX,myY,20,20);
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
            DrawRectangleGradientEx(myRect,WHITE,BLACK,WHITE,BLACK);
            //use "myString[chosenString]" to randomize letters
            //Convert.ToString(this.ID)
            DrawText(testText,myX,myY,19,RED);
        }

        public void wave()
        {
            waveXY = new Vector2(waveX,waveY);
            DrawPixelV(waveXY,WHITE);

            waveX++;

        }



        public void DrawThis()
        {
            mySquare();
            if (WAVE)
            {
                this.testText = "*";
                wave();
            }


        }
    }
}
