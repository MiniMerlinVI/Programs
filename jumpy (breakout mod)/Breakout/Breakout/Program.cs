using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace Breakout
{

    static class Program
    {

        // STATE
        // Keep the state of the elements of the game here (variables hold state).
        // ...
        public static int BallX = 135;
        public static int BallY = 464;
        public static bool BallBob = false;

        public static int CoinFaze = 0;
        public static int CoinX = 270;
        public static int CoinY = 30;
        public static bool CoinCollected = false;

        public static int FallSpeed = 2;

        public static int Jump = 0;
        public static bool Jumped = false;

        public static bool BrickFloor = false;

        public static bool DPress = false;
        public static bool APress = false;
        public static bool WPress = false;
        public static bool SPress = false;

        public static bool DKeyCheck = false;
        public static bool AKeyCheck = false;
        public static bool WKeyCheck = false;
        public static bool SKeyCheck = false;
        // This procedure is called (invoked) for each window refresh (FPS - about 40 times a second)
        static void onTick(object sender, TickEventArgs args)
        {

            // STEP
            // Update the automagic elements and enforce the rules of the game here.
            // ...
            
            if (DPress == true)
            {
                BallX = BallX + 2;
                
            }
            if (APress == true)
            {
                BallX = BallX - 2;
            }
            if (BallX < -32)
            {
                BallX = 640;
                
            }
            if (BallX > 640)
            {
                BallX = -32;
            }
            if (WPress == true && Jumped == false)
            {
                Jump = Jump + 50;
                Jumped = true;
                WPress = false;
            }
            if (Jump > 0)
            {
                    BallY = BallY - 1;
                    Jump = Jump - 1;                   
            }
            if (Jump == 0)
            {
                Jumped = false;
            }
            if (BallY + 16 <= 480 && Jumped == false) // checks if ball is on floor or is jumping
            {
                if (BallY + 16 >= 420 && BallY + 18 <= 452 && BallX <= 436 && BallX >= 300 || BallY + 16 >= 370 && BallY + 16 <= 402 && BallX <= 240 && BallX >= 120 || BallY + 16 >= 310 && BallY + 16 <= 342 && BallX >= 330 && BallX <= 450 || BallY + 16 >= 240 && BallY + 16 <= 272 && BallX >= 150 && BallX <= 270 || BallY + 16 >= 190 && BallY + 16 <= 202 && BallX >= 340 && BallX <= 460 || BallY + 16 >= 120 && BallY + 16 <= 152 && BallX >= 120 && BallX <= 240) // 340 190 // 120 120 // checks if ball is on pad
                {

                    if (BallY < 420 || BallY < 370 || BallY < 310 || BallY < 190 || BallY < 120)
                    {
                        BallY = BallY - 1;
                    }

                }
                
                else 
                {

                    BallY = BallY + FallSpeed; // gravity
                    
                }
             }
            //if (BallBob == false)
            //{
            //    BallY = BallY - 1;
            //    BallBob = true;
            //}
            //else if (BallBob == true)
            //{
            //    BallY = BallY + 1;
            //    BallBob = false;
            //}
            if (BallY + 8 >= 30 && BallY + 8 <= 60 && BallX + 8 >= 270 && BallX + 8 <= 300) //270 30
            {
                CoinCollected = true;
            }
                // DRAW
            // Draw the new view of the game based on the state of the elements here.
            // ...

            drawBackground(); // 640 480

            

            drawSprite(Sprite.ball_small, BallX, BallY);
            drawSprite(Sprite.bat_large, 300, 420);
            drawSprite(Sprite.bat_medium, 120, 370);
            drawSprite(Sprite.bat_medium, 330, 310);
            drawSprite(Sprite.bat_medium,150, 240);
            drawSprite(Sprite.bat_small, 340, 190);
            drawSprite(Sprite.bat_small, 120, 120);
            // drawSprite(Sprite.bat_medium,,);
            
            

            // ANIMATE 
            // Step the animation frames ready for the next tick
            // ...
            if (Jump >= 0)
            {
                BallY = BallY - 3;
                Jump = Jump - 1;
            }
            if (CoinCollected == false)
            {
                if (CoinFaze == 0) //coin animator test
                {
                    drawSprite(Sprite.coin_00, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 1)
                {
                    drawSprite(Sprite.coin_01, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 2)
                {
                    drawSprite(Sprite.coin_02, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 3)
                {
                    drawSprite(Sprite.coin_03, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 4)
                {
                    drawSprite(Sprite.coin_04, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 5)
                {
                    drawSprite(Sprite.coin_05, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 6)
                {
                    drawSprite(Sprite.coin_06, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 7)
                {
                    drawSprite(Sprite.coin_07, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 8)
                {
                    drawSprite(Sprite.coin_08, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 9)
                {
                    drawSprite(Sprite.coin_09, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 10)
                {
                    drawSprite(Sprite.coin_10, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 11)
                {
                    drawSprite(Sprite.coin_11, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 12)
                {
                    drawSprite(Sprite.coin_12, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 13)
                {
                    drawSprite(Sprite.coin_13, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 14)
                {
                    drawSprite(Sprite.coin_14, CoinX, CoinY);
                    CoinFaze = CoinFaze + 1;
                }
                else if (CoinFaze == 15)
                {
                    drawSprite(Sprite.coin_15, CoinX, CoinY);
                    CoinFaze = 0;
                }
            }
            // REFRESH
            // Tranfer the new view to the screen for the user to see.
            video.Update();

        }

        // this procedure is called when the mouse is moved
        static void onMouseMove(object sender, SdlDotNet.Input.MouseMotionEventArgs args)
        {
            // ...
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
            
            

            if (DKeyCheck == false && args.KeyboardCharacter == "d")
            {
                DPress = true;
                DKeyCheck = true;
            }
            else if (DKeyCheck == true && args.KeyboardCharacter == "d")
            {
                DPress = false;
                DKeyCheck = false;
            }
            if (AKeyCheck == false && args.KeyboardCharacter == "a")
            {
                APress = true;
                AKeyCheck = true;
            }
            else if (AKeyCheck == true && args.KeyboardCharacter == "a")
            {
                APress = false;
                AKeyCheck = false;
            }

            if (WKeyCheck == false && args.KeyboardCharacter == "w")
            {
                WPress = true;
                WKeyCheck = true;
            }
            else if (WKeyCheck == true && args.KeyboardCharacter == "w")
            {
                WPress = false;
                WKeyCheck = false;
            }
            
            if (SKeyCheck == false && args.KeyboardCharacter == "s")
            {
                SPress = true;
                SKeyCheck = true;
            }
            else if (SKeyCheck == true && args.KeyboardCharacter == "s")
            {
                SPress = false;
                SKeyCheck = false;
            }



            
            
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

            // Create display surface.
            video = Video.SetVideoMode(FRAME_WIDTH, FRAME_HEIGHT, COLOUR_DEPTH, FRAME_RESIZABLE, USE_OPENGL, FRAME_FULLSCREEN, USE_HARDWARE);
            Video.WindowCaption = "Breakout";
            Video.WindowIcon(new Icon(@"breakout.ico"));

            // invoke application initialisation subroutine
            setup();

            // register event handler subroutines
            Events.Tick += new EventHandler<TickEventArgs>(onTick);
            Events.Quit += new EventHandler<QuitEventArgs>(onQuit);
            Events.KeyboardDown += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(onKeyboard);
            Events.KeyboardUp += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(onKeyboard);
            Events.MouseButtonDown += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(onMouseButton);
            Events.MouseButtonUp += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(onMouseButton);
            Events.MouseMotion += new EventHandler<SdlDotNet.Input.MouseMotionEventArgs>(onMouseMove);

            // while not quit do process events
            Events.TargetFps = 120;
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
