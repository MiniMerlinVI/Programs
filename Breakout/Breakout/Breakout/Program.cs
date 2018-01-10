using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace Breakout
{

    static class Program
    {
        public static int BatX = 0;
        public static int BatY = 0;

        public static bool YBounce = false;
        public static bool XBounce = false;

        public static int BallX = 340;
        public static int BallY = 380;     

        public static int[,] BrickPoint_x = new int[7, 6];
        public static int[,] BrickPoint_y = new int[7, 6];
        //static Sprite[,] BrickPoint_sprite = new Sprite[7, 6];
        public static bool[,] BrickPoint_gone = new bool[7, 6];

        // STATE
        // Keep the state of the elements of the game here (variables hold state).
        // ...


        // This procedure is called (invoked) before the first onTick
        static void onInit()
        {

            for (int i = 0; i < 7; ++i) //7
            {

                for (int j = 0; j < 6; j++) // 6
                {

                    BrickPoint_x[i, j] = i * 40 + 180; // 180

                    BrickPoint_y[i, j] = j * 40 + 30; // 30

                    //BrickPoint_sprite[i, j] = (Sprite)j;

                    BrickPoint_gone[i, j] = false;

                }
            }
        }

        // This procedure is called (invoked) for each window refresh (FPS - about 40 times a second)
        static void onTick(object sender, TickEventArgs args)
        {


            // STEP
            // Update the automagic elements and enforce the rules of the game here.
            // ...
            
            // COLLISIONS
            for (int i = 0; i < 7; i++) //7
            {
                for (int j = 0; j < 6; ++j) // 6
                {                  
                   if (BrickPoint_gone[i, j] == false && BallY <= BrickPoint_y[i, j] + 30 && BallY >= BrickPoint_y[i, j] + 20 && BallX + 8 <= BrickPoint_x[i, j] + 20 && BallX + 8 >= BrickPoint_x[i, j] + 10) //S 
                   {
                       YBounce = true;
                       BrickPoint_gone[i, j] = true;
                   }
                    if (BrickPoint_gone[i, j] == false && BallX + 16 <= BrickPoint_x[i, j] + 10 && BallX + 16 >= BrickPoint_x[i, j] && BallY <= BrickPoint_y[i, j] + 30 && BallY >= BrickPoint_y[i, j] + 20) //SW 
                    {
                        XBounce = false;
                        YBounce = true;
                        BrickPoint_gone[i, j] = true;
                    }
                    if (BrickPoint_gone[i, j] == false && BallX + 16 <= BrickPoint_x[i, j] + 10 && BallX + 16 >= BrickPoint_x[i, j] && BallY <= BrickPoint_y[i, j] + 20 && BallY >= BrickPoint_y[i, j] + 10) //W 
                    {
                        XBounce = false;
                        BrickPoint_gone[i, j] = true;
                    }
                    if (BrickPoint_gone[i, j] == false && BallX + 16 <= BrickPoint_x[i, j] + 10 && BallX + 16 >= BrickPoint_x[i, j] && BallY <= BrickPoint_y[i, j] + 10 && BallY >= BrickPoint_y[i, j]) //NW
                    {
                        YBounce = false;
                        XBounce = false;
                        BrickPoint_gone[i, j] = true;
                    }
                    if (BrickPoint_gone[i, j] == false && BallY + 16 <= BrickPoint_y[i, j] + 10 && BallY + 16 >= BrickPoint_y[i, j] && BallX + 8 <= BrickPoint_x[i, j] + 20 && BallX + 8 >= BrickPoint_x[i, j] + 10) // N
                    {
                        YBounce = false;
                        BrickPoint_gone[i, j] = true;
                    }
                    if (BrickPoint_gone[i, j] == false && BallY + 16 <= BrickPoint_y[i, j] + 10 && BallY + 16 >= BrickPoint_y[i, j] && BallX <= BrickPoint_x[i, j] + 30 && BallX >= BrickPoint_x[i, j] + 20) //NE
                    {
                        YBounce = false;
                        XBounce = true;
                        BrickPoint_gone[i, j] = true;
                    }
                    if (BrickPoint_gone[i, j] == false && BallX <= BrickPoint_x[i, j] + 30 && BallX >= BrickPoint_x[i, j] + 20 && BallY + 8 <= BrickPoint_y[i, j] + 20 && BallY + 8 >= BrickPoint_y[i, j] + 30) //E
                    {
                        XBounce = true;
                        BrickPoint_gone[i, j] = true;
                    } 
                    if (BrickPoint_gone[i, j] == false && BallX <= BrickPoint_x[i, j] + 30 && BallX >= BrickPoint_x[i, j] + 20 && BallY <= BrickPoint_x[i, j] + 30 & BallY >= BrickPoint_y[i, j] + 20) // SE 
                    {
                       YBounce = true;
                        XBounce = true;
                        BrickPoint_gone[i, j] = true;
                    }
                    //random error somewhere (cannot find it)

                    //NEW flips movement if ball section of brick? test
                    
                   }

            }

            if (BallY <= 0)
            {
                YBounce = true;
            }

            if (BallY + 16 >= 480 || BallX <= BatX + 120 && BallX >= BatX & BallY == 384)
            {
                YBounce = false;
            }

            // BAT MOVEMENT
            if (BatX + 120 <= 640 || BatX > 0)
            {
            }
            if (BatX + 120 >= 640)
            {
                BatX = 520;
            }
            if (BatX <= 0)
            {
                BatX = 0;
            }

            if (BallX <= 158) //left side
            {
                XBounce = true;
            }

            if (BallX >= 468) //right side
            {
                XBounce = false;
            }
            // DRAW
            // Draw the new view of the game based on the state of the elements here.
            // ...

            drawBackground();

            for (int x = 0; x < 7; x++) // 7
            {

                for (int y = 0; y < 6; ++y) // 6
                {
                    if (BrickPoint_gone[x, y] == false)
                    {
                        drawSprite(Sprite.brick_stone, BrickPoint_x[x, y], BrickPoint_y[x, y]); // BrickPoint_sprite[x, y]
                    }
                }
            }

            drawSprite(Sprite.fire, 600, 6);
            drawSprite(Sprite.ice, 600, 40);
            drawSprite(Sprite.bat_medium, BatX, 400);
            drawSprite(Sprite.ball_small, BallX, BallY);

            // ANIMATE 
            // Step the animation frames ready for the next tick
            // ...

            if (YBounce == true)
            {
                BallY = BallY + 2;
            }
            if (YBounce == false)
            {
                BallY = BallY - 2;
            }
            if (XBounce == true)
            {
                BallX = BallX + 2;
            }
            if (XBounce == false)
            {
                BallX = BallX - 2;
            }
            // REFRESH
            // Tranfer the new view to the screen for the user to see.
            video.Update();

        }

        // this procedure is called when the mouse is moved
        static void onMouseMove(object sender, SdlDotNet.Input.MouseMotionEventArgs args)
        {
            // ...

            BatX = BatX + args.RelativeX;
            BatY = BatY + args.RelativeY;

        }

        // this procedure is called when a mouse button is pressed or released
        static void onMouseButton(object sender, SdlDotNet.Input.MouseButtonEventArgs args)
        {
            // ...

        }

        // this procedure is called when a key is pressed or released
        static void onKeyboard(object sender, SdlDotNet.Input.KeyboardEventArgs args)
        {
            // ...

        }

        // --------------------------
        // ----- GAME Utilities -----  You can use these, don't change them.
        // --------------------------

        // draw the background image onto the frame
        static void drawBackground()
        {
            video.Blit(imgBackground);
        }

        // draw the sprite image onto the frame
        // Sprite sprite - which sprite to draw
        // int x, int y - the co-ordinates of where to draw the sprite on the frame.
        static void drawSprite(Sprite sprite, int x, int y)
        {
            video.Blit(imgSpriteSheet, new Point(x, y), sprite_sheet_cut[(int)sprite]);
        }

        // ============================================
        // ============ Here Be Dragons ===============
        // ============================================
        // == Don't invoke or modify the code below! == 
        // ============================================

        // ------ Break-Out Graphics Engine - -------

        // -- APPLICATION ENTRY POINT --

        static void Main()
        {
            System.Windows.Forms.Cursor.Hide();
            // Create display surface.
            video = Video.SetVideoMode(FRAME_WIDTH, FRAME_HEIGHT, COLOUR_DEPTH, FRAME_RESIZABLE, USE_OPENGL, FRAME_FULLSCREEN, USE_HARDWARE);
            Video.WindowCaption = "Breakout";
            Video.WindowIcon(new Icon(@"breakout.ico"));

            // invoke application initialisation subroutine
            setup();

            // secondary initialization
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
        static void setup()
        {

            // Load Art

            imgBackground = new Surface(@"breakout_bg.png").Convert(video, true, false);

            imgSpriteSheet = new Surface(@"breakout_sprites.png");

            // Specify where each sprite is in the sprite-sheet

            // Generate sprite_sheet_cut Rectangles for the first 40 small (40x40) sprites
            {
                int s = (int)Sprite.red;  // sprite_sheet_cut index
                int x = 0;
                int y = 0;
                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 0; j < 10; ++j)
                    {
                        sprite_sheet_cut[s] = new Rectangle(x, y, 40, 40);
                        s = s + 1;
                        x = x + 40;
                    }
                    x = 0;
                    y = y + 40;
                }
            }

            // Generate sprite_sheet_cut Rectangles for the 16 coins (24x24) sprites
            {
                int s = (int)Sprite.coin_00; // sprite_sheet_cut index
                int x = 0;
                int y = 376;
                for (int i = 0; i < 16; ++i)
                {
                    sprite_sheet_cut[s] = new Rectangle(x, y, 24, 24);
                    s = s + 1;
                    x = x + 24;
                }
            }

            // Odd Shape Sprites
            sprite_sheet_cut[(int)Sprite.bat_small] = new Rectangle(0, 200, 104, 32);
            sprite_sheet_cut[(int)Sprite.bat_medium] = new Rectangle(0, 240, 120, 32);
            sprite_sheet_cut[(int)Sprite.bat_large] = new Rectangle(0, 280, 136, 32);

            sprite_sheet_cut[(int)Sprite.ball_small] = new Rectangle(160, 200, 16, 16);
            sprite_sheet_cut[(int)Sprite.ball_large] = new Rectangle(160, 240, 24, 24);

            sprite_sheet_cut[(int)Sprite.cross] = new Rectangle(200, 160, 80, 80);
            sprite_sheet_cut[(int)Sprite.flare] = new Rectangle(320, 160, 80, 80); ;
            sprite_sheet_cut[(int)Sprite.swirl] = new Rectangle(200, 280, 80, 80); ;
            sprite_sheet_cut[(int)Sprite.spiral] = new Rectangle(320, 280, 80, 80); ;
        }

        // This procedure is called when the event loop receives an exit event (window close button is pressed)
        static void onQuit(object sender, QuitEventArgs args)
        {
            Events.QuitApplication();
        }

        // -- DATA --

        const int FRAME_WIDTH = 640;
        const int FRAME_HEIGHT = 480;
        const int COLOUR_DEPTH = 32;
        const bool FRAME_RESIZABLE = false;
        const bool FRAME_FULLSCREEN = false;
        const bool USE_OPENGL = false;
        const bool USE_HARDWARE = true;

        static Surface video;  // the window on the display

        static Surface imgBackground;
        static Surface imgSpriteSheet;

        // Sprite Identifiers

        enum Sprite
        {
            red, purple, yellow,
            blue1, blue2, green1, green2,
            star,
            rubble, stone, bricks,
            left_rubble, right_rubble, left_stone, right_stone,
            iron_mask, jade_mask, opal_mask, ruby_mask,
            brick_rubble, brick_stone, tile_stone,
            jade, ruby, opal,
            ice, fire,
            jar,
            smooth_rock, dented_rock, smashed_rock,
            black_galaxy, blue_galaxy,
            blue_ring,
            orb_fire, orb_water,
            totem, totem_wink,
            left, right, up, down,
            bat_small, bat_medium, bat_large,
            ball_small, ball_large,
            cross, flare, swirl, spiral,
            coin_00, coin_01, coin_02, coin_03,
            coin_04, coin_05, coin_06, coin_07,
            coin_08, coin_09, coin_10, coin_11,
            coin_12, coin_13, coin_14, coin_15
        };

        // All the sprites come from one large image, this is called a 
        // sprite-sheet. For each sprite, we need to know which part (Rectangle)
        // of the larger sheet to use.  We store these rectangles in a variable
        // called sprite_sheet_cut for later use.
        // It is easier and more efficient to store one big image rather than lots
        // of little ones, especially if they are stored in the graphics memory.
        // (You can find the sprite-sheet for many games online - be careful of copyright!)
        // *The Rectangles are stored in the same sequence as the Sprite enum.
        static Rectangle[] sprite_sheet_cut = new Rectangle[40 + 16 + 11];

    }
}





