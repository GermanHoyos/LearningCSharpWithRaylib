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
    public class UnitCircle4 : MyGame_1
    {
        int angleChangeCountX = 0;
        int angleChangeCountY = 0;
        float angleOfIncidence, remainderAngle;
        float changedAngle;
        float centerX = 600.00F, centerY = 350.00F, radius = 50.00F, angleDegree = 173, reflect = 0f;  //required for shape and interior angle drawings
        float angleConverted, endPosX, endPosY;                                                         //required for shape and interior angle drawings
        float xVel = 3f, yVel = 3f, friction, mass, xNewVector, yNewVector;                             //required for movement
        float top = 270.00F , right = 180.00F, bottom = 90.00F, left = 0.00F;                           //reflection angles for hitting walls
        float screenHeight = 450.00F, screenWidth = 800.00F;
        public Vector2 sin, cos, center, endPos;

        public UnitCircle4(){}

        public void calculateAngles()
        {
            this.angleConverted = this.angleDegree / 180.00F * 3.14F;
            this.endPosX = this.centerX + this.radius * (float)(Math.Cos(this.angleConverted));
            this.endPosY = this.centerY - this.radius * (float)(Math.Sin(this.angleConverted));
            this.center = new Vector2(this.centerX, this.centerY);
            this.endPos = new Vector2(this.endPosX, this.endPosY);
            this.sin = new Vector2(this.endPosX, this.centerY);
            this.cos = new Vector2(this.endPosX, this.centerY);
            DrawText("ChangeCount:  " + Convert.ToString(this.angleChangeCountX), (int)this.centerX - (int)this.radius, (int)this.centerY - (int)this.radius - 65, 20, MAROON);
            DrawText("Angle:  " + Convert.ToString(this.angleDegree), (int)this.centerX - (int)this.radius, (int)this.centerY - (int)this.radius - 25, 20, MAROON);
            DrawText("X:  " + Convert.ToString(Math.Round(this.centerX)), (int)this.centerX - (int)this.radius, (int)this.centerY - (int)this.radius - 45, 20, MAROON);
            DrawText("Y:  " + Convert.ToString(Math.Round(this.centerY)), (int)this.centerX + (int)this.radius - 5, (int)this.centerY - (int)this.radius - 45, 20, MAROON);


            //left + right bounce only
            if (this.centerX < 50 && this.angleChangeCountX < 1)
            {
                this.angleChangeCountX++;
                this.changedAngle = ((this.angleDegree + 180) % 360) * -1;
                this.angleDegree = 360 - Math.Abs(this.changedAngle);

            }
            if (this.centerX > 750 && this.angleChangeCountX < 1)
            {
                this.angleChangeCountX++;
                this.changedAngle = ((this.angleDegree + 180) % 360) * -1;
                this.angleDegree = 360 - Math.Abs(this.changedAngle);
            }
            //left + right buffer
            if (this.centerX > 51 && this.centerX < 749)
            {
                this.angleChangeCountX = 0;
            }





            //travel in the direction of calculated angles above
            this.centerX += (float)(Math.Cos(this.angleConverted)) * this.xVel;         //move circle x based on this.angleConverted * some speed
            this.centerY -= (float)(Math.Sin(this.angleConverted)) * this.yVel;         //move circle y based on this.angleConverted * some speed
        }

        public void DrawLines()
        {
            DrawCircleSectorLines(this.center ,this.radius, 0F, 360F, 0, WHITE);    //circle outline
            DrawLineV(this.center, this.endPos, WHITE);                                                     //angle
            DrawLineV(this.endPos, this.sin, GREEN);                                                        //sin
            DrawLineV(this.center, this.cos, RED);                                                          //cos
        }
        public void DrawThis()
        {
            this.calculateAngles();
            this.DrawLines();




        }
    }
}
