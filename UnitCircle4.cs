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
        float centerX = (800f / 2f), centerY = (450f / 2f), radius = 50.00f, angleDegree = 45;  
        float radians, endPosX, endPosY;                                                         
        float xVelocityInPixels = 1f, yVelocityInPixels = 1f;
        float tX = 740, tY = 125;
        public Vector2 maximaMinima, center, endPosVec2;
        public Vector2 finalUnitVecOfCircle;
        public Vector2 targetXY;
        public Vector2 directionEndPos;
        public static Vector2 unitVectorOfCirlce;
        public static float  magnitude;


        public UnitCircle4()
        {
            //key formulas:
            //sin(x) =          1 dimensional direction, either -1 or 1, gets the direction of a vector 
            //abs(x) =          length or magnitude
            //distance(a,b) =   1 dimensional: abs(b - a) 
            //scale =           a set of numbers, amounts, etc. used to measure or compare the level of something
            //scalars =         number rules that apply to 1 dimension, sort of like 1 dimensional vectors
            //vector =          a single point in space in relation to another point in space ie: (2,3) in relation to (0,0) on a 2d graph
            //components =      refer to the single referenced axis in a vector, ie: Vector2(2,3): 2 = x component, 3 = y component
            //magnitude =       the measured length of scaled individual increments based on some abritrary scale ie: (4) = length of "4" from 0,1,2,3,(4)
            //vectorLength =    Math.sqrt(x^2 + y^2)
            //normalization =   the process of making a vectors length or magnitude 1, ie: |v| = length   v with ^ ontop = direction
                                //this gets the direction to a non unit 1 vector
            //howTo normalize = unitVector V = x/vectorLength, y/vectorLength
            //whyNormalize =    once a vector is normalized, you can move at a fixed rate of speed towards a direction ie: normalizedVector * speed
            //negation =        flip the arrow vector about its origin, ie: (2,1) negated = (-1,-2) [ /\ visually ]
            //unit vector =     directions in a unit vector circle whose length or magnitude is 1
        }

        public void testTarget()
        {
            targetXY = new Vector2(tX, tY);
            DrawText("Target", (int)tX - 30, (int)tY, 20, MAROON);
            DrawPixelV(targetXY,WHITE);
            tX--;
        }

        //normalize the the direction to a point with respect to the centerX and centerY of this circle
        public static Vector2 NormalizeDirToPt(float centerX, float centerY, float tX, float tY)
        {
            Vector2 direction = new Vector2(tX - centerX, tY - centerY);
            magnitude = direction.Length();
            if (magnitude > 0)
            {
                direction /= magnitude;
            }
            return direction;            
        }

        public void calculateAngles()
        {
            //targeting properties
            finalUnitVecOfCircle = NormalizeDirToPt(centerX,centerY,tX,tY);
            directionEndPos = center + finalUnitVecOfCircle * radius;
            unitVectorOfCirlce = directionEndPos - center;

            //circle object properties
            center = new Vector2(centerX, centerY);
            radians = angleDegree / 180.00f * 3.14f;
            endPosX = centerX + radius * (float)(Math.Cos(radians));
            endPosY = centerY - radius * (float)(Math.Sin(radians));
            endPosVec2 = new Vector2(endPosX, endPosY);
            maximaMinima = new Vector2(directionEndPos.X, centerY); //the point at which COS and SIN intersect and end
        }

        public void DrawLines()
        {
            DrawCircleSectorLines(center ,radius, 0F, 360F, 0, WHITE); //circle outline
            DrawLineV(center, directionEndPos, WHITE); //angle
            DrawLineV(directionEndPos, maximaMinima, GREEN); //sin
            DrawLineV(center, maximaMinima, RED); //cos
            DrawLineV(center, directionEndPos, WHITE);
            DrawLine(215,0,215,450,RED); //left console
        }

        public void DrawThisText()
        {
            //DrawText("Angle:  " + Convert.ToString(angleDegree), (int)centerX - (int)radius, (int)centerY - (int)radius - 25, 20, MAROON);
            //DrawText("X:  " + Convert.ToString(Math.Round(centerX)), (int)centerX - (int)radius, (int)centerY - (int)radius - 45, 20, MAROON);
            //DrawText("Y:  " + Convert.ToString(Math.Round(centerY)), (int)centerX + (int)radius - 5, (int)centerY - (int)radius - 45, 20, MAROON);
            //DrawText("Target dist: " + Convert.ToString(Math.Round(distanceFromCenterOfCircle)), 10, 90, 20, MAROON);
            //DrawText("Radius dist:  ", 10, 110, 20, MAROON);      
        }

        public void DrawThis()
        {
            calculateAngles();
            DrawLines();
            DrawThisText();
            testTarget();
        }
    }
}
