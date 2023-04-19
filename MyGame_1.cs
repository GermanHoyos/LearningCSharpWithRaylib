/*******************************************************************************************
    Coded by: German Adrian Hoyos
    Jesus is my lord and saviour
********************************************************************************************/

using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System;

namespace Examples.MyRaylibGames
{
    public class MyGame_1
    {
        public static int Main()
        {

            //Game Variable inits
            const int screenWidth = 800;
            const int screenHeight = 450;
            int fps;
            double getTime;
            double oldTime = Convert.ToInt16(GetTime());
            int seconds = 0;
            int minutes = 0;

            //Window setup
            InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");
            SetTargetFPS(60);

            //Object Instantiations
            UnitCircleOne myCircle = new UnitCircleOne();

            // Main game loop
            while (!WindowShouldClose())    
            {
                //Update or Declare variables here that need to be updated every tick
                fps = GetFPS(); 

                //Time Counting Functionality
                getTime = Convert.ToInt16(GetTime()); //Elapsed time in seconds since init window
                if (oldTime != getTime)
                {
                   seconds++;
                   if (seconds == 60)
                   {
                        seconds = 0;
                        minutes++;
                   }
                   oldTime = getTime;
                }

                //Begin drawing context
                BeginDrawing();
                ClearBackground(BLACK);

                //Show FPS / Minutes / Seconds
                DrawText("FPS:  ", 10, 10, 20, MAROON);
                DrawText("Seconds:  ", 10, 30, 20, MAROON);
                DrawText("Minutes:  ", 10, 50, 20, MAROON);
                DrawText(Convert.ToString(fps), 65, 10, 20, MAROON);
                DrawText(Convert.ToString(Convert.ToInt32(seconds)), 110, 30, 20, MAROON);
                DrawText(Convert.ToString(Convert.ToInt32(minutes)), 100, 50, 20, MAROON);

                //Instantiate game objects
                myCircle.DrawThis();

                //End drawing context
                EndDrawing();
            }

            // De-Initialization
            // Close window and OpenGL context
            CloseWindow();        


            return 0;
        }
    }
}
