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
    public class ProtoTypeUnitCircle : MyGame_1
    {
        float centerX = (800f / 2f), centerY = (450f / 2f), radius = 50.00f, tX = 740, tY = 125;  
        public Vector2 maximaMinima, center, endPosVec2;
        public Vector2 finalUnitVecOfCircle;
        public Vector2 targetXY;
        public Vector2 directionEndPos;
        public static float  magnitude;

        public ProtoTypeUnitCircle()
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
            finalUnitVecOfCircle = NormalizeDirToPt(centerX,centerY,tX,tY); // normalized to target / direction
            directionEndPos = center + finalUnitVecOfCircle * radius; //show direction line
            center = new Vector2(centerX, centerY);// center of sphere
            maximaMinima = new Vector2(directionEndPos.X, centerY); //the point at which COS and SIN intersect and end
        }

        public void DrawLines()
        {
            DrawCircleSectorLines(center ,radius, 0F, 360F, 0, WHITE); //circle outline
            DrawLineV(center, directionEndPos, WHITE); //DIRECTION
            DrawLineV(directionEndPos, maximaMinima, GREEN); //SIN
            DrawLineV(center, maximaMinima, RED); //COS
        }

        public void DrawThisText()
        {
            DrawText("Vector in relation", 10, 355, 20, MAROON);
            DrawText("to center: ", 10, 370, 20, MAROON);
            DrawText("Unit Vector X: " + Convert.ToString(Math.Round(finalUnitVecOfCircle.X, 2)), 10, 390, 20, MAROON);
            DrawText("Unit Vector Y: " + Convert.ToString(Math.Round(finalUnitVecOfCircle.Y, 2)), 10, 410, 20, MAROON);
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
