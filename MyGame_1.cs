///*******************************************************************************************
//    Coded by: German Adrian Hoyos
//    Jesus is my lord and saviour
//********************************************************************************************/

//using Raylib_cs;
//using static Raylib_cs.Raylib;
//using static Raylib_cs.Color;
//using System;
//using System.ComponentModel;
//using System.Numerics;

//namespace Examples.MyRaylibGames
//{
//    public class MyGame_1
//    {

//        // Check if any key is pressed
//        // NOTE: We limit keys check to keys between 32 (KEY_SPACE) and 126
//       public static bool IsAnyKeyPressed()
//        {
//            bool keyPressed = false;
//            int key = GetKeyPressed();

//            if(key >= 32 && key <= 126)
//            {
//                keyPressed = true;
//                return keyPressed;
//            }
//            return keyPressed;
//        }

//        public static int Main()
//        {

//            //Window variables
//            const int screenWidth = 800;
//            const int screenHeight = 450;
//            int fps = 60; //initial value of sixty does not dictate fps... see "SetTargetFPS(60);"

//            //Timing variables
//            double getTime;
//            double oldTime = Convert.ToInt16(GetTime());
//            int seconds = 0;
//            int minutes = 0;
//            double deltaTime = (double)(1m / 60m); //initial value of "1 / 60" does not dictate deltaTime... see "deltaTime = 1 / fps;"

//            //Additional physics variables
//            float canvas_friction = 0.3F;
//            float canvas_gravity = 0.5F;

//            //Window setup / initialization
//            InitWindow(screenWidth, screenHeight, "Set your mind free");

//            // Define the camera to look into our 3d world
//            Camera3D camera = new Camera3D();
//            camera.position = new Vector3(10.0f, 10.0f, 10.0f);
//            camera.target = new Vector3(0.0f, 0.0f, 0.0f);
//            camera.up = new Vector3(0.0f, 1.0f, 0.0f);
//            camera.fovy = 45.0f;
//            camera.projection = CameraProjection.CAMERA_PERSPECTIVE;


//            SetTargetFPS(60);

//            //Input variables
//            string pressedKey = "";
//            Vector2 mouseClickPos = new (0,0);

//            //Object variables
//            Vector2 dotXY = new Vector2 (400,200);
//            float variator = 0;

//            //Object Instantiations
//            for (int i = 0; i < 660; i++) 
//            {
//               //push 100 instances of the GridCellClass into an array.
//               ListOfObjects.gridList.Add(new GridCellClass()); 
//            }


//            SetCameraMode(camera, CameraMode.CAMERA_ORBITAL);


//            // Main game loop
//            while (!WindowShouldClose())    
//            {
//                //Update or Declare variables here that need to be updated every tick
//                fps = GetFPS();

//                //this may be a good entry point for 3d
//                UpdateCamera(ref camera);

//                //Detect key board input
//                bool keyWasPressed = IsAnyKeyPressed();
//                if (keyWasPressed)
//                {
//                   pressedKey = Convert.ToString((char)GetCharPressed());
//                }

//                //Detect mouse click x and y pos
//                bool mouseLeftPress = IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT);
//                if (mouseLeftPress)
//                {
//                    mouseClickPos = GetMousePosition();
//                }

//                //Time Counting Functionality
//                getTime = Convert.ToInt16(GetTime()); //Elapsed time in seconds since init window
//                if (oldTime != getTime)
//                {
//                   seconds++;
//                   if (seconds == 60)
//                   {
//                        seconds = 0;
//                        minutes++;
//                   }
//                   oldTime = getTime;
//                }

//                //Delta Time - used for FPS independent animations
//                if (fps > 0) //fps will briefly be 0 upon window initialization
//                {
//                    deltaTime = (double)(1m / fps);
//                    Globals.globalFPS = GetFPS();
//                    Globals.globalDT = deltaTime; //Every class can access this in said namespace
//                    //Delta time concepts and implementation:
//                        //1) Delta time is the difference between the current and the previous frame
//                        //2) Multiplying deltaTime with any movement in the game will make the game look
//                        //3)
//                        //consistant despite frame rate
//                        //Implement: MOVEMENT * FRAMERATE * DELTATIME
//                }

                

//                //Begin drawing context
//                BeginDrawing();

//               BeginMode3D(camera);

//                //DrawModel(models[currentModel], new(0, 0, 0), 1.0f, WHITE);
//                DrawGrid(10, 1.0f);

//                EndMode3D();

                

//                ClearBackground(BLACK);

//                //Show FPS / Minutes / Seconds / DeltaTime
//                DrawText("FPS:  ", 10, 10, 20, MAROON);
//                DrawText("Seconds:  ", 10, 30, 20, MAROON);
//                DrawText("Minutes:  ", 10, 50, 20, MAROON);
//                DrawText("Delta Time:  ", 10, 70, 20, MAROON);
//                DrawText("Key Press:  ", 10, 90, 20, MAROON);
//                DrawText("Click:  ", 10, 115, 20, MAROON);
//                DrawText(Convert.ToString(fps), 65, 10, 20, MAROON);
//                DrawText(Convert.ToString(Convert.ToInt32(seconds)), 110, 30, 20, MAROON);
//                DrawText(Convert.ToString(Convert.ToInt32(minutes)), 100, 50, 20, MAROON);
//                DrawText(Convert.ToString(Math.Round(deltaTime, 4)), 125, 70, 20, MAROON); // to verify this, simply change set point of FPS and see this value adjust
//                DrawText(Convert.ToString(pressedKey), 125, 90, 20, MAROON);
//                DrawText(Convert.ToString(Convert.ToString(mouseClickPos.X) + " " + Convert.ToString(mouseClickPos.Y)), 70, 115, 20, MAROON);

//                //Console line sperator
//                DrawLine(200,0,200,450,RED); //left console

//                variator += 0.1F;
//                float offset = 0;
//                //draw circle this many times and at this x position
//                for (int i = 210; i < 800; i += 20)
//                {
//                    float b = variator + offset;
//                    //Vector2 dotXY = new Vector2 (400,200); (X, Y)
//                    //SIN: y = a * sin(b(x-c)) + d
//                    dotXY.Y =  30 * (float)Math.Sin(b) + 200;
//                    //COS: y = a * cos(k(x-d)) + c
//                    //dotXY.X = 30 * (float)Math.Cos(variator) + 400;
//                    dotXY.X = i;
//                    DrawCircleV(dotXY, 10, WHITE);
//                    offset += 1f;
                    
//                }


//                //End drawing context
//                EndDrawing();
//            }

//            // De-Initialization
//            // Close window and OpenGL context
//            CloseWindow();        

//            return 0;
//        }
//    }
//}


/*******************************************************************************************
*
*   raylib [models] example - Load models vox (MagicaVoxel)
*
*   This example has been created using raylib 4.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Johann Nadalutti (@procfxgen) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2021 Johann Nadalutti (@procfxgen) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.IO;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.MouseButton;
using static Raylib_cs.KeyboardKey;
using System;

namespace Examples.MyRaylibGames
{
    public class MyGame_1
    {
        const int MAX_VOX_FILES = 3;

        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 800;
            const int screenHeight = 450;

            //string[] voxFileNames = new string[MAX_VOX_FILES] {
            //    "resources/models/vox/chr_knight.vox",
            //    "resources/models/vox/chr_sword.vox",
            //    "resources/models/vox/monu9.vox"
            //};

            InitWindow(screenWidth, screenHeight, "::Adrian Hoyos::");

            // Define the camera to look into our 3d world
            Camera3D camera = new Camera3D();
            camera.position = new Vector3(10.0f, 10.0f, 10.0f);
            camera.target = new Vector3(0.0f, 0.0f, 0.0f);
            camera.up = new Vector3(0.0f, 1.0f, 0.0f);
            camera.fovy = 45.0f;
            camera.projection = CameraProjection.CAMERA_PERSPECTIVE;

            // Load MagicaVoxel files
            //Model[] models = new Model[MAX_VOX_FILES];

            //for (int i = 0; i < MAX_VOX_FILES; i++)
            //{
            //    // Load VOX file and measure time
            //    double t0 = GetTime() * 1000.0;
            //    models[i] = LoadModel(voxFileNames[i]);
            //    double t1 = GetTime() * 1000.0;

            //    TraceLog(TraceLogLevel.LOG_WARNING, $"[{voxFileNames[i]}] File loaded in {t1 - t0} ms");

            //    // Compute model translation matrix to center model on draw position (0, 0 , 0)
            //    BoundingBox bb = GetModelBoundingBox(models[i]);
            //    Vector3 center = new();
            //    center.X = bb.min.X + (((bb.max.X - bb.min.X) / 2));
            //    center.Z = bb.min.Z + (((bb.max.Z - bb.min.Z) / 2));

            //    Matrix4x4 matTranslate = Matrix4x4.CreateTranslation(-center.X, 0, -center.Z);
            //    models[i].transform = Matrix4x4.Transpose(matTranslate);
            //}

            //3d object properties
            
            float sphereRadius = .3f;
            float x = 0f;
            float y = 0f;
            float z = 0f;
            float angle= 0.1f;

            Vector3 sphereCenter = new Vector3(x,y,z);


            int currentModel = 0;
            SetCameraMode(camera, CameraMode.CAMERA_ORBITAL);

            SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                UpdateCamera(ref camera);      // Update our camera to orbit

                // Cycle between models on mouse click
                //if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT))
                //{
                //    currentModel = (currentModel + 1) % MAX_VOX_FILES;
                //}

                // Cycle between models on key pressed
                //if (IsKeyPressed(KEY_RIGHT))
                //{
                //    currentModel++;
                //    if (currentModel >= MAX_VOX_FILES)
                //    {
                //        currentModel = 0;
                //    }
                //}
                //else if (IsKeyPressed(KEY_LEFT))
                //{
                //    currentModel--;
                //    if (currentModel < 0)
                //    {
                //        currentModel = MAX_VOX_FILES - 1;
                //    }
                //}
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(BLACK);

                // Draw 3D model
                BeginMode3D(camera);


//                variator += 0.1F;
//                float offset = 0;
//                //draw circle this many times and at this x position
//                for (int i = 210; i < 800; i += 20)
//                {
//                    float b = variator + offset;
//                    //Vector2 dotXY = new Vector2 (400,200); (X, Y)
//                    //SIN: y = a * sin(b(x-c)) + d
//                    dotXY.Y =  30 * (float)Math.Sin(b) + 200;
//                    //COS: y = a * cos(k(x-d)) + c
//                    //dotXY.X = 30 * (float)Math.Cos(variator) + 400;
//                    dotXY.X = i;
//                    DrawCircleV(dotXY, 10, WHITE);
//                    offset += 1f;
                    
//                }

                angle += 0.1f;
                float offset = 0;
                for (int i = -5; i < 6; i++){

                    float a = (angle + offset);
                    sphereCenter.Y =  1f * (float)Math.Sin(a);
                    sphereCenter.X = i;
                    DrawSphere(sphereCenter,sphereRadius,GREEN);
                    DrawGrid(10, 1.0f);
                    offset += 1f;
                   
                }

               







                EndMode3D();

                // Display info
                DrawRectangle(10, 400, 380, 35, Fade(SKYBLUE, 0.5f));
                DrawRectangleLines(10, 400, 380, 35, Fade(DARKBLUE, 0.5f));
                DrawText("Formula:  y = a * sin(b(x-c)) + d", 40, 410, 20, GREEN);

                //string fileName = Path.GetFileName(voxFileNames[currentModel]);
                //DrawText($"File: {fileName}", 10, 10, 20, GRAY);

                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            // Unload models data (GPU VRAM)
            //for (int i = 0; i < MAX_VOX_FILES; i++)
            //{
            //    UnloadModel(models[i]);
            //}

            CloseWindow();          // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
