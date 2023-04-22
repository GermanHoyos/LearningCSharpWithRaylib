using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using Raylib_cs;
using System.Numerics;

namespace Examples.MyRaylibGames
{
    public class UnitCircleTwo
    {
        public UnitCircleTwo(){}

        public Vector2 startPoint = new(100.00F, 150.00F);
        public Vector2 endPoint = new(200.00F, 150.00F);
        

        public void DrawThis()
        {
            DrawLineV(startPoint,endPoint,RAYWHITE);
        }
    }
}
