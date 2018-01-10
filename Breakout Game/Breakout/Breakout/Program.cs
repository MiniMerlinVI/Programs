using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace Breakout
{

    public class Program
    {

        static Ball playerBall;
        static Bat playerBat;
        static Brick[,,] Brick = new Brick[2,7,4];

        static int batVelocity = 0;

        static void onInit()
        {

            playerBall = new Ball(312, 4, 384, 4, true, Sprite.ball_small);
            playerBat = new Bat(260, 284, Sprite.bat_medium);

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Brick[0, x, y] = new Brick((x * 40 + 180), (y * 40 + 30), false, Sprite.brick_stone);
                    Brick[1, x, y] = new Brick((x * 40 + 180), (y * 40 + 415), false, Sprite.brick_stone);
                }
            }

        }

        static void onTick(object sender, TickEventArgs args)
        {
            for (int b = 0; b < 2; b++ )
            {
                for (int x = 0; x < 7; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (Brick[b, x, y].getBroken() == false)
                        {
                            if (playerBall.getY() <= Brick[b, x, y].getY() + 30 && playerBall.getY() >= Brick[b, x, y].getY() + 20 && playerBall.getX() + 8 <= Brick[b, x, y].getX() + 20 && playerBall.getX() + 8 >= Brick[b, x, y].getX() + 10) //S 
                            {
                                playerBall.setYVelocity(4);
                                Brick[b, x, y].setBroken(true);
                            }
                            if (playerBall.getX() + 16 <= Brick[b, x, y].getX() + 10 && playerBall.getX() + 16 >= Brick[b, x, y].getX() && playerBall.getY() <= Brick[b, x, y].getY() + 30 && playerBall.getY() >= Brick[b, x, y].getY() + 20) //SW 
                            {
                                playerBall.setXVelocity(-4);
                                playerBall.setYVelocity(4);
                                Brick[b, x, y].setBroken(true);
                            }
                            if (playerBall.getX() + 16 <= Brick[b, x, y].getX() + 10 && playerBall.getX() + 16 >= Brick[b, x, y].getX() && playerBall.getY() <= Brick[b, x, y].getY() + 20 && playerBall.getY() >= Brick[b, x, y].getY() + 10) //W 
                            {
                                playerBall.setXVelocity(-4);
                                Brick[b, x, y].setBroken(true);
                            }
                            if (playerBall.getX() + 16 <= Brick[b, x, y].getX() + 10 && playerBall.getX() + 16 >= Brick[b, x, y].getX() && playerBall.getY() <= Brick[b, x, y].getY() + 10 && playerBall.getY() >= Brick[b, x, y].getY()) //NW
                            {
                                playerBall.setYVelocity(-4);
                                playerBall.setXVelocity(-4);
                                Brick[b, x, y].setBroken(true);
                            }
                            if (playerBall.getY() + 16 <= Brick[b, x, y].getY() + 10 && playerBall.getY() + 16 >= Brick[b, x, y].getY() && playerBall.getX() + 8 <= Brick[b, x, y].getX() + 20 && playerBall.getX() + 8 >= Brick[b, x, y].getX() + 10) // N
                            {
                                playerBall.setYVelocity(-4);
                                Brick[b, x, y].setBroken(true);
                            }
                            if (playerBall.getY() + 16 <= Brick[b, x, y].getY() + 10 && playerBall.getY() + 16 >= Brick[b, x, y].getY() && playerBall.getX() <= Brick[b, x, y].getX() + 30 && playerBall.getX() >= Brick[b, x, y].getX() + 20) //NE
                            {
                                playerBall.setYVelocity(-4);
                                playerBall.setXVelocity(4);
                                Brick[b, x, y].setBroken(true);
                            }
                            if (playerBall.getX() <= Brick[b, x, y].getX() + 30 && playerBall.getX() >= Brick[b, x, y].getX() + 20 && playerBall.getY() + 8 <= Brick[b, x, y].getY() + 20 && playerBall.getY() + 8 >= Brick[b, x, y].getY() + 30) //E
                            {
                                playerBall.setXVelocity(4);
                                Brick[b, x, y].setBroken(true);
                            }
                            if (playerBall.getX() <= Brick[b, x, y].getX() + 30 && playerBall.getX() >= Brick[b, x, y].getX() + 20 && playerBall.getY() <= Brick[b, x, y].getY() + 30 & playerBall.getY() >= Brick[b, x, y].getY() + 20) // SE 
                            {
                                playerBall.setYVelocity(4);
                                playerBall.setXVelocity(4);
                                Brick[b, x, y].setBroken(true);
                            }
                        }
                    }
                }
            }

            if (playerBall.getX() <= 158)
            {
                playerBall.setXVelocity(4);
            }
            if (playerBall.getX() >= 468)
            {
                playerBall.setXVelocity(-4);
            }
            if (playerBall.getY() <= 0)
            {
                playerBall.setYVelocity(4);
            }
            if (playerBall.getY() + 16 >= 600)
            {
                playerBall.setYVelocity(-4);
            }
            if (playerBall.getX() >= playerBat.getX() && playerBall.getX() + 16 <= playerBat.getX() + 120)
            {
                if (playerBall.getY() + 16 >= playerBat.getY() && playerBall.getY() + 16 <= playerBat.getY() + 16)
                {
                    playerBall.setYVelocity(-2);
                }
                if (playerBall.getY() >= playerBat.getY() + 16 && playerBall.getY() <= playerBat.getY() + 32)
                {
                    playerBall.setYVelocity(2);
                }
            }

            playerBall.setX(playerBall.getX() + playerBall.getXVelocity());
            playerBall.setY(playerBall.getY() + playerBall.getYVelocity());
            playerBat.setX(playerBat.getX() + batVelocity);

            drawBackground();

            playerBall.draw();
            playerBat.draw();

            for (int b = 0; b < 2; b++)
            {
                for (int x = 0; x < 7; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (Brick[b, x, y].getBroken() == false)
                        {
                            Brick[b, x, y].draw();
                        }
                    }
                }
            }

            video.Update();

        }

        static void onMouseMove(object sender, SdlDotNet.Input.MouseMotionEventArgs args)
        {
            playerBat.setX(args.X - 60);
        }

        static void onMouseButton(object sender, SdlDotNet.Input.MouseButtonEventArgs args)
        {
            
        }

        static void onKeyboardDown(object sender, SdlDotNet.Input.KeyboardEventArgs args)
        {
            if (args.KeyboardCharacter == "a")
            {
                batVelocity = -3;
            }
            if (args.KeyboardCharacter == "d")
            {
                batVelocity = 3;
            }
        }

        static void onKeyboardUp(object sender, SdlDotNet.Input.KeyboardEventArgs args)
        {
            if (args.KeyboardCharacter == "a")
            {
                batVelocity = 0;
            }
            if (args.KeyboardCharacter == "d")
            {
                batVelocity = 0;
            }
        }

        static void drawBackground()
        {
            video.Blit(imgBackground);
        }

        static void drawSprite(Sprite sprite, int x, int y)
        {           
            video.Blit(imgSpriteSheet, new Point(x , y), sprite_sheet_cut[(int)sprite]);
        }

        static void Main()
        {

            video = Video.SetVideoMode(FRAME_WIDTH, FRAME_HEIGHT, COLOUR_DEPTH, FRAME_RESIZABLE, USE_OPENGL, FRAME_FULLSCREEN, USE_HARDWARE);
            Video.WindowCaption = "Breakout";
            Video.WindowIcon(new Icon(@"breakout.ico"));

            setup();

            Events.Tick += new EventHandler<TickEventArgs>(onTick);
            Events.Quit += new EventHandler<QuitEventArgs>(onQuit);
            Events.KeyboardDown += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(onKeyboardDown);
            Events.KeyboardUp += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(onKeyboardUp);
            Events.MouseButtonDown += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(onMouseButton);
            Events.MouseButtonUp += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(onMouseButton);
            Events.MouseMotion += new EventHandler<SdlDotNet.Input.MouseMotionEventArgs>(onMouseMove);

            Events.TargetFps = 120;
            Events.Run();
        }
        static void setup()
        {

            imgBackground = new Surface(@"breakout_bg.png").Convert(video, true, false);

            imgSpriteSheet = new Surface(@"breakout_sprites.png");

            {
                int s = (int)Sprite.red;
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
            {
                int s = (int)Sprite.coin_00;
                int x = 0;
                int y = 376;
                for (int i = 0; i < 16; ++i)
                {
                    sprite_sheet_cut[s] = new Rectangle(x, y, 24, 24);
                    s = s + 1;
                    x = x + 24;
                }
            }

            sprite_sheet_cut[(int)Sprite.bat_small] = new Rectangle(0, 200, 104, 32);
            sprite_sheet_cut[(int)Sprite.bat_medium] = new Rectangle(0, 240, 120, 32);
            sprite_sheet_cut[(int)Sprite.bat_large] = new Rectangle(0, 280, 136, 32);

            sprite_sheet_cut[(int)Sprite.ball_small] = new Rectangle(160, 200, 16, 16);
            sprite_sheet_cut[(int)Sprite.ball_large] = new Rectangle(160, 240, 24, 24);

            sprite_sheet_cut[(int)Sprite.cross] = new Rectangle(200, 160, 80, 80);
            sprite_sheet_cut[(int)Sprite.flare] = new Rectangle(320, 160, 80, 80); ;
            sprite_sheet_cut[(int)Sprite.swirl] = new Rectangle(200, 280, 80, 80); ;
            sprite_sheet_cut[(int)Sprite.spiral] = new Rectangle(320, 280, 80, 80); ;

            onInit();

        }

        static void onQuit(object sender, QuitEventArgs args)
        {
            Events.QuitApplication();
        }

        const int FRAME_WIDTH = 640;
        const int FRAME_HEIGHT = 600;
        const int COLOUR_DEPTH = 32;
        const bool FRAME_RESIZABLE = false;
        const bool FRAME_FULLSCREEN = false;
        const bool USE_OPENGL = false;
        const bool USE_HARDWARE = true;

        public static Surface video;

        public static Surface imgBackground;
        public static Surface imgSpriteSheet;

        public enum Sprite
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

        public static Rectangle[] sprite_sheet_cut = new Rectangle[40 + 16 + 11];

    }
}
