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

        public static char genRandomChar()
        {
            char[] charArray = {'*','!','$'};
            int x = GetRandomValue(0,2);
            char chosenChar = charArray[x];     
            return chosenChar;
        }

        public static int[] genRandomColors()
        {
            int r = GetRandomValue(0,255);
            int g = GetRandomValue(0,255);
            int b = GetRandomValue(0,255);
            int[] rgbArray = {r,g,b};
            return rgbArray;
        }

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

        //Wave animation initial values
        public bool WAVE = false;
        float waveX = 100;
        float waveY = 10;
        public Vector2 waveXY;

        //default constructor
        public GridCellClass(){}

        //constructor that builds the grid
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

        //how each individual square looks
        public void mySquare()
        {   
            
            int[] colors = genRandomColors();
            Raylib_cs.Color colorChosen = new Raylib_cs.Color(1,colors[0],colors[1],colors[2]); 

            DrawRectangleGradientEx(myRect,colorChosen,BLACK,WHITE,BLACK);
            DrawText(testText,myX,myY,19,WHITE);

        }

        //algorithm to modify square properties over time
        public void wave()
        {
            //create shape and interate
            waveXY = new Vector2(waveX,waveY);
            DrawPixelV(waveXY,WHITE);
            waveX++;

            //reflect shape in grid
            foreach (GridCellClass i in ListOfObjects.gridList)
            {

                if (i.myX < waveX)
                {
                    char charChosen = genRandomChar();
                    i.testText = Convert.ToString(charChosen);
                }
            }
        }

        public void DrawThis()
        {
            //draw all instantiated squares
            mySquare();

            if (WAVE)
            {
                this.testText = "*";
                wave();
            }


        }
    }
}
