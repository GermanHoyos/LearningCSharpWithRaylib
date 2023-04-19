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

        //bool vars for determining how object behaves
        //will this object be player controlled or self controlled
        bool selfControlled = true; // default to this, overloaded constructor can change
        bool gravityOn = false;     //can be changed dependent on behaviour mode

        //this objects id for removal upon deletion
        int id;

        //minimum shape data needed
        int x = 40;
        int y = 150;
        int radius = 10;
        string color = "RED";

        //motion vars + grab needed global vars and place here
        int     xVelocity, yVelocity;
        int     angleVelocity = 1;
        float   min_xVelocity, min_yVelocity;
        float   deltaTime;

        //angles and vector vars
        public static float rawAngle = 0.00F;
        double angle_1 = rawAngle / (float)180 * Math.PI;
        
        //default constructor = no params, default selfControlled true
        public UnitCircleOne(){}

        //overloaded constructor = just shape and position, default selfControlled true
        public UnitCircleOne(int x, int y, int radius, string color)
        {
            this.x = x; this.y = y; this.radius = radius; this.color = color;
        }

        //overloaded constructor = all params defalt selfControled true
        public UnitCircleOne
        (
            int x, int y, int radius, string color,
            int xVelocity, int yVelocity, float min_xVelocity, float min_yVelocity
        )
        {
            this.x = x; this.y = y; this.radius = radius; this.color = color;
            this.xVelocity = xVelocity; this.yVelocity = yVelocity;
            this.min_xVelocity = min_xVelocity; this.min_yVelocity = min_yVelocity;
        }

        //overloaded constructor = all params + option to change self controlled to false
        public UnitCircleOne
        (
            int x, int y, int radius, string color, int xVelocity, int yVelocity,
            float min_xVelocity, float min_yVelocity, bool selfControlled
        )
        {
            this.x = x; this.y = y; this.radius = radius; this.color = color;
            this.xVelocity = xVelocity; this.yVelocity = yVelocity;
            this.min_xVelocity = min_xVelocity; this.min_yVelocity = min_yVelocity;
            this.selfControlled = selfControlled;
        }

        //draw circle shape
        public void DrawShape()
        {
            DrawCircleLines(x, y, radius, RED);
        }

        //draw angles + cos + sin
        public void DrawAngles()
        {
            //test all 360 angles
            angle_1 = rawAngle / (float)180 * Math.PI;
            rawAngle += angleVelocity * (float)(Globals.globalFPS) * (float)(Globals.globalDT);
            if (rawAngle == 360) {rawAngle = 0.00F;}

            //convert end points
            int endPosX = (int)(this.x + this.radius * Math.Cos(angle_1)); //COS  
            int endPosY = (int)(this.y - this.radius * Math.Sin(angle_1)); //SIN

            //angle
            DrawLine(this.x, this.y,endPosX, endPosY,WHITE);

            //sin
            DrawLine(endPosX,endPosY,endPosX, this.y,GREEN);
            
            //cos
            DrawLine(this.x, this.y, endPosX,this.y,RED);
        }
        

        //self generated movement with or without gravity
        public void selfGenMovement()
        {
            //without gravity:

            //with gravity:

        }

        //user generated movement with or without gravity
        public void userGenMovement()
        {
            //without gravity:

            //with gravity:

        }

        //draw method
        public void DrawThis()
        {
            //gloabal vars required for animation
            this.deltaTime = (float)(Math.Round(Globals.globalDT,3));

            //if this object exists
            this.DrawShape();
            this.DrawAngles();



        }

    }
}
