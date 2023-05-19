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
        //default values to be itereated on throughout instantiations
        public static int thisID    = 1;
        public static int thisX     = 175;
        public static int thisY     = 5;
        public string cellText      = "o";
        Raylib_cs.Color backgroundColor = RAYWHITE;
        Raylib_cs.Color cellTextColor = Raylib_cs.Color.BLACK;
        public Rectangle myRect;

        public int ID { get; set; }
        public int myX { get; set; }
        public int myY { get; set; }
        public string myCellText { get; set; }
        public Raylib_cs.Color myBackgroundColor { get; set; }
        public Raylib_cs.Color myCellTextColor { get; set; }


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

        //constructor that builds the grid
        public GridCellClass()
        {
            ID = thisID++;
            thisX += 20;

            //screenwidth - this cells individual width
            if (thisX > 800 - 20)
            {
                thisY += 20;
                thisX = 195;
            }

            myX = thisX;
            myY = thisY;
            myCellText = cellText;
            myBackgroundColor = backgroundColor;
            myCellTextColor = cellTextColor;

            myRect = new Rectangle(myX, myY, 20, 20);
        }

        //visual properties of individual cells
        public void mySquare()
        {
            
            //example of randomizing all values:
                //backgroundColor = Algorithm_Anim01.genRandomColors();
                //cellTextColor = Algorithm_Anim01.genRandomColors();
                //cellText = Convert.ToString(Algorithm_Anim01.genRandomChar());

            DrawRectangleGradientEx(myRect, myBackgroundColor,myBackgroundColor,myBackgroundColor,myBackgroundColor);
            DrawText(myCellText, myX + 5, myY + 2, 19, myCellTextColor);
        }

        public void DrawThis()
        {
            //draw all instantiated squares
            mySquare();
        }
    }
}
