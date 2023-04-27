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

  public class UnitCircleTwo
  {
    float centerX, centerY, radius, angleDegree, angleConverted, endPosX, endPosY;
    public Vector2 sin, cos, center, endPos;

    public UnitCircleTwo()
    {
        //initial values
        centerX = 700.00F;
        centerY = 50.00F;
        radius = 50.00F;
        angleDegree = 140.00F;
    }

    public void DrawThis()
    {
        //calculate lines
        angleConverted = angleDegree / 180.00F * 3.14F;
        endPosX = centerX + radius * (float)(Math.Cos(angleConverted));
        endPosY = centerY - radius * (float)(Math.Sin(angleConverted));
        center = new Vector2(centerX, centerY);
        endPos = new Vector2(endPosX, endPosY);
        sin = new Vector2(endPosX, centerY);
        cos = new Vector2(endPosX,centerY);
        //move lines
        angleDegree++;
        //circle outline
        DrawCircleSectorLines(center ,radius, 0F, 360F, 0, WHITE);
        //angle line
        DrawLineV(center, endPos, WHITE);
        //sin line
        DrawLineV(endPos, sin, GREEN);
        //cos line
        DrawLineV(center, cos, RED);
    }

  }

}
