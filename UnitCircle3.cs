using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using Raylib_cs;
using System.Numerics;
using System.Drawing;

namespace Examples.MyRaylibGames
{
    public class UnitCircle3
    {
        public float centerX, centerY, radius, angleDegree, angleConverted, endPosX, endPosY; //required for shape and interior angle drawings
        public float xVel, yVel, friction, mass, xNewVector, yNewVector;                      //required for movement
        public Vector2 sin, cos, center, endPos;

        public UnitCircle3()
        {
            //initial values                  
            centerX =       700.00F;
            centerY =       250.00F;
            radius =        50.00F;
            angleDegree =   140.00F;
        }

        public void calculateAngles()
        {
            angleConverted = angleDegree / 180.00F * 3.14F;
            endPosX = centerX + radius * (float)(Math.Cos(angleConverted));
            endPosY = centerY - radius * (float)(Math.Sin(angleConverted));
            center = new Vector2(centerX, centerY);
            endPos = new Vector2(endPosX, endPosY);
            sin = new Vector2(endPosX, centerY);
            cos = new Vector2(endPosX,centerY);
            if (this.angleDegree>= 360)
            {
                this.angleDegree = 0;
            }
            if (this.angleDegree < 0)
            {
                this.angleDegree = 359;
            }


        }

        public void DrawLines()
        {
            DrawCircleSectorLines(center ,radius, 0F, 360F, 0, WHITE); //circle outline
            DrawLineV(center, endPos, WHITE);      //angle
            DrawLineV(endPos, sin, GREEN);  //sin
            DrawLineV(center, cos, RED);    //cos
            DrawText("Angle:  " + Convert.ToString(this.angleDegree), (int)this.centerX - (int)this.radius, (int)this.centerY - (int)this.radius - 25, 20, MAROON);
        }

        public void thisObjectMovement()
        {
            centerX += (float)(Math.Cos(angleConverted)) * .5f;
            centerY -= (float)(Math.Sin(angleConverted)) * .5f;
            angleDegree--;
        }

        public void DrawThis()
        {
            this.calculateAngles();
            this.DrawLines();
            this.thisObjectMovement();
        }
    }
}
