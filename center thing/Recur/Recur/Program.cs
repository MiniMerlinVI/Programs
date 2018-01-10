using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Core;

using System.Collections.Generic;
using System.IO;

namespace Shmup {

    // == Program, Entry Point ==

        

    static class Program {

        public struct Ball
        {
            public double x { get; set; }
            public double y { get; set; }

            public Ball(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

        }

        public static Ball[,] Balls = new Ball[6, 2];

        public static void onInit() {
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                int num = rnd.Next(50, 100);
                for (int j = 0; j < 2; j++)
                {
                    Balls[i, j] = new Ball(400,300);
                    double rad = (num * i) * Math.PI / 180.0;
                    double dx = ((j * 50) + 50) * Math.Cos(rad);
                    double dy = ((j * 50) + 50) * Math.Sin(rad) * -1.0;
                    Balls[i,j].x = Balls[i,j].x + dy;
                    Balls[i, j].y = Balls[i, j].y - dx;
                }
            }

            



        }

        // Draw on the surface
        // This procedure is called (invoked) on each onTick
        static void onDraw(Surface image) {

            // Put your code to draw on the surface here

            image.Fill(Color.Wheat);


            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Circle circle = new Circle(Convert.ToInt16(Balls[i, j].x), Convert.ToInt16(Balls[i, j].y), Convert.ToInt16(13 - j));
                    circle.Draw(image, Color.Red, true, false);
                    Line line = new Line(new Point(Convert.ToInt16(Balls[i, 0].x), Convert.ToInt16(Balls[i, 0].y)), new Point(Convert.ToInt16(Balls[i, 1].x), Convert.ToInt16(Balls[i, 1].y)));
                    line.Draw(image, Color.Black);
                }
            }
          
        }

        // This procedure is called (invoked) for each window refresh
        static void onTick(object sender, TickEventArgs args) {

            // STEP
            // Update the state of the elements here.

            // DRAW
            // Draw the new view based on the state of the elements here.
            onDraw(image);
            video.Blit(image);

            // ANIMATE 
            // Step the animation frames ready for the next tick.

            // REFRESH
            // Tranfer the new view to the screen for the user to see.
            video.Update();

        }

        // this procedure is called when the mouse is moved
        static void onMouseMove(object sender, SdlDotNet.Input.MouseMotionEventArgs args) {

        }

        // this procedure is called when a mouse button is pressed or released
        static void onMouseButton(object sender, SdlDotNet.Input.MouseButtonEventArgs args) {

        }

        // this procedure is called when a key is pressed or released
        static void onKeyboard(object sender, SdlDotNet.Input.KeyboardEventArgs args) {

            if (args.Down) { 

                switch (args.Key) {
                    case SdlDotNet.Input.Key.RightArrow :
                        for (int i = 0; i < 6; i++)
                        {
                            Balls[i, 1].x++;
                        }
                        break;
                    case SdlDotNet.Input.Key.LeftArrow :
                        for (int i = 0; i < 6; i++)
                        {
                            Balls[i, 1].x--;

                        }
                        break;
                    case SdlDotNet.Input.Key.UpArrow :
                        for (int i = 0; i < 6; i++)
                        {

                            Balls[i, 1].y--;
                        }
                        break;
                    case SdlDotNet.Input.Key.DownArrow:
                        for (int i = 0; i < 6; i++)
                        {
                            Balls[i, 1].y++;
                                                }
                        break;
                    case SdlDotNet.Input.Key.Space :
                        break;
                        
                    case SdlDotNet.Input.Key.Escape :
                        Events.QuitApplication();
                        break;
                }

            } else {

                switch (args.Key) {
                    case SdlDotNet.Input.Key.RightArrow :
                    case SdlDotNet.Input.Key.LeftArrow :
                        break;
                }

            }

        }

        // --------------------------
        // ----- GAME Utilities -----  
        // --------------------------

        // -- APPLICATION ENTRY POINT --

        static void Main() {
            //System.Windows.Forms.Cursor.Hide();

            // Create display surface.
            video = Video.SetVideoMode(FRAME_WIDTH, FRAME_HEIGHT, COLOUR_DEPTH, FRAME_RESIZABLE, USE_OPENGL, FRAME_FULLSCREEN, USE_HARDWARE);
            Video.WindowCaption = "Recur";
            Video.WindowIcon(new Icon(@"images/tree-icon.ico"));

            // invoke application initialisation subroutine
            setup();

            // invoke secondary initialisation subroutine
            onInit();

            // register event handler subroutines
            Events.Tick += new EventHandler<TickEventArgs>(onTick);
            Events.Quit += new EventHandler<QuitEventArgs>(onQuit);
            Events.KeyboardDown += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(onKeyboard);
            Events.KeyboardUp += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(onKeyboard);
            Events.MouseButtonDown += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(onMouseButton);
            Events.MouseButtonUp += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(onMouseButton);
            Events.MouseMotion += new EventHandler<SdlDotNet.Input.MouseMotionEventArgs>(onMouseMove);

            // while not quit do process events
            Events.TargetFps = 60;
            Events.Run();
        }

        // This procedure is called after the video has been initialised but before any events have been processed.
        static void setup() {
            image = video.CreateCompatibleSurface();
        }

        // This procedure is called when the event loop receives an exit event (window close button is pressed)
        static void onQuit(object sender, QuitEventArgs args) {
            Events.QuitApplication();
        }

        // -- DATA --

        const int FRAME_WIDTH = 800;
        const int FRAME_HEIGHT = 600;
        const int COLOUR_DEPTH = 32;
        const bool FRAME_RESIZABLE = false;
        const bool FRAME_FULLSCREEN = false;
        const bool USE_OPENGL = false;
        const bool USE_HARDWARE = true;

        static Surface video;  // the window on the display
        static Surface image;

    }
}
