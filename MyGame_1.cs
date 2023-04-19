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

            //Window variables
            const int screenWidth = 800;
            const int screenHeight = 450;
            int fps = 60; //initial value of sixty does not dictate fps... see "SetTargetFPS(60);"

            //Timing variables
            double getTime;
            double oldTime = Convert.ToInt16(GetTime());
            int seconds = 0;
            int minutes = 0;
            double deltaTime = (double)(1m / 60m); //initial value of "1 / 60" does not dictate deltaTime... see "deltaTime = 1 / fps;"

            //Drawing context variables
            float canvas_friction = 0.3F;
            float canvas_gravity = 0.5F;

            //Window setup / initialization
            InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");
            SetTargetFPS(60);

            //Game Object Instantiations
            //UnitCircleOne myCircle = new UnitCircleOne();
            UnitCircleOne myCircle = new UnitCircleOne(410, 170, 50,"RED");

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

                //Delta Time - used for FPS independent animations
                if (fps > 0) //fps will briefly be 0 upon window initialization
                {
                    deltaTime = (double)(1m / fps);
                    Globals.globalFPS = GetFPS();
                    Globals.globalDT = deltaTime; //Every class can access this in said namespace
                    //Delta time concepts and implementation:
                        //1) Delta time is the difference between the current and the previous frame
                        //2) Multiplying deltaTime with any movement in the game will make the game look
                        //3)
                        //consistant despite frame rate
                        //Implement: MOVEMENT * FRAMERATE * DELTATIME
                }

                //Begin drawing context
                BeginDrawing();
                ClearBackground(BLACK);

                //Show FPS / Minutes / Seconds / DeltaTime
                DrawText("FPS:  ", 10, 10, 20, MAROON);
                DrawText("Seconds:  ", 10, 30, 20, MAROON);
                DrawText("Minutes:  ", 10, 50, 20, MAROON);
                DrawText("Delta Time:  ", 10, 70, 20, MAROON);
                DrawText(Convert.ToString(fps), 65, 10, 20, MAROON);
                DrawText(Convert.ToString(Convert.ToInt32(seconds)), 110, 30, 20, MAROON);
                DrawText(Convert.ToString(Convert.ToInt32(minutes)), 100, 50, 20, MAROON);
                DrawText(Convert.ToString(Math.Round(deltaTime, 4)), 125, 70, 20, MAROON); // to verify this, simply change set point of FPS and see this value adjust

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
