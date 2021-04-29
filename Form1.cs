using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class elevator
    {
        public Bitmap im;
        public int x, y;

    }
    public class enemybullet
    {
        public Bitmap im;
        public int x, y;

    }
    public class boss
    {
        public Bitmap im;
        public int x, y, health;
    }
    public class gift
    {
        public Bitmap im;
        public int x, y;
    }
    public class box
    {
        public Bitmap im;
        public int x, y;
    }
    public class block
    {
        public Bitmap im;
        public int x, y;
    }
    public class bullet
    {
        public Bitmap im;
        public int x, y;
    }
    public class gun
    {
        public Bitmap im;
        public int x, y;
    }
    public class back
    {
        public Bitmap im;
    }
    public class enemy
    {
        public Bitmap im;
        public int x, y;
    }
    class hero
    {
        public Bitmap im;
        public int x, y;
    }
    public partial class Form1 : Form
    {
        int numVal = Int32.Parse("-105");
        int score;
        int countTick = 0;
        Random rnd;
        Bitmap off;
        int move;
        int lives = 3;
        int w;
        int hw, hh;
        int move2 = 400;
        Timer t = new Timer();
        int scount;
        int fastl, fast, r;
        List<gun> guns = new List<gun>();
        int c = 1;
        Random rnd2;
        List<elevator> elevators = new List<elevator>();
        List<enemybullet> enemybullets = new List<enemybullet>();
        List<boss> bosses = new List<boss>();
        List<back> backgrounds = new List<back>();
        List<hero> heros = new List<hero>();
        List<enemy> enemies = new List<enemy>();
        List<bullet> bullets = new List<bullet>();
        List<block> blocks = new List<block>();
        List<gift> gifts = new List<gift>();
        int u;
        List<box> boxes = new List<box>();
        string start;
        int st;
        int ct;
        int pos = -1;
        int back = 0;
        int ct2 = 0;
        int big = 0;
        int l = 1;
        int ct3;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load1;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;
            t.Tick += T_Tick;
            t.Interval = 1;

            t.Start();

        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (bosses[0].health <= 0)
            {
                st = 0;
            }
            if (u == 0)
            {
                blocks[0].y += 10;
                if (blocks[0].y >= this.ClientSize.Height - 20)
                {
                    u = 1;
                }
            }
            if (u == 1)
            {
                blocks[0].y -= 10;
                if (blocks[0].y < 20)
                {
                    u = 0;
                }
            }

            if (heros[0].x >= blocks[0].x && heros[0].x <= blocks[0].x + 100 && heros[0].y < blocks[0].y)
            {
                w = 1;
                if (u == 0)
                {
                    heros[0].y += 10;
                    guns[0].y += 10;
                    if (heros[0].y >= this.ClientSize.Height - 20)
                    {
                        u = 1;
                    }
                }
                if (u == 1)
                {
                    heros[0].y -= 10;
                    guns[0].y -= 10;
                    if (heros[0].y < 20)
                    {
                        u = 0;
                    }
                }

            }







            rnd = new Random();
            if (countTick % 30 == 0 && heros[0].x > this.ClientSize.Width / 2)
            {
                enemybullet pnn = new enemybullet();
                pnn.y = rnd.Next(600, 800);
                pnn.x = 1400;
                pnn.im = new Bitmap("fire1.png");
                pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
                enemybullets.Add(pnn);

            }
            for (int i = 0; i < enemybullets.Count; i++)
            {
                enemybullets[i].x -= 10;
            }

            for (int i = 0; i < enemybullets.Count; i++)
            {
                if (enemybullets[i].x > heros[0].x && enemybullets[i].x < heros[0].x + 70 && enemybullets[i].y >= heros[0].y && enemybullets[i].y < heros[0].y + heros[0].im.Height)
                {
                    lives = 0;
                }
            }


            if (lives == 0)
            {
                st = 0;
            }
            if (countTick % 15 == 0)
            {
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (heros[0].y <= boxes[i].y + 120 && heros[0].x >= boxes[i].x && heros[0].x < boxes[i].x + 100)
                    {
                        gift pnn = new gift();
                        pnn.im = new Bitmap("mashrom.jpg");
                        pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
                        pnn.x = boxes[i].x;
                        pnn.y = boxes[i].y - 50;
                        boxes[i].y -= 50;
                        big = 1;
                        gifts.Add(pnn);

                    }
                }
            }
            if (countTick % 1 == 0)
            {
                for (int i = 0; i < gifts.Count; i++)
                {

                    gifts[i].x += 10;

                }

            }
            if (countTick % 1 == 0)
            {
                for (int i = 0; i < gifts.Count; i++)
                {
                    if (heros[0].x >= gifts[i].x && heros[0].x < gifts[i].x + 50 && gifts[i].y == 750)
                    {
                        gifts.Remove(gifts[i]);
                        hh += 30;
                        hw += 30;
                        heros[0].y -= 20;

                    }
                }
            }
            if (countTick % 20 == 0)
            {
                for (int i = 0; i < gifts.Count; i++)
                {
                    gifts[i].y = 750;


                }
            }
            if (countTick % 1 == 0)
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    bullets[i].x += 30;
                }
            }
            rnd = new Random();
            if (countTick % 70 == 0)
            {
                enemy pnm = new enemy();
                pnm.im = new Bitmap("enemies11.png");
                pnm.im.MakeTransparent(pnm.im.GetPixel(0, 0));
                pnm.x = rnd.Next(1200, 1600);
                pnm.y = 750;
                enemies.Add(pnm);
            }
            if (countTick % 5 == 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {

                    enemies[i].x -= 20;
                    if (l >= 5)
                    {
                        l = 1;
                    }

                    enemies[i].im = new Bitmap("enemies1" + l + ".png");
                    l++;
                }
            }
            if (ct2 == 1 && countTick % 1 == 0)
            {
                heros[0].y -= 10;
                guns[0].y -= 10;
                if (heros[0].y <= 600)
                {
                    ct2 = 2;
                }
            }
            if (ct2 == 2 && countTick % 1 == 0)
            {
                heros[0].y += 10;
                guns[0].y += 10;
                if (heros[0].y >= 715 && big == 0)
                {
                    heros[0].im = new Bitmap("marios1.png");
                    heros[0].im.MakeTransparent(heros[0].im.GetPixel(0, 0));
                    ct2 = 0;
                }
                if (heros[0].y >= 700 && big == 1)
                {
                    heros[0].im = new Bitmap("marios1.png");
                    heros[0].im.MakeTransparent(heros[0].im.GetPixel(0, 0));
                    ct2 = 0;
                }

            }

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].x >= heros[0].x && enemies[i].x <= heros[0].x + 40)
                {
                    ct2 = 1;
                    lives--;
                    enemies[i].x -= 30;
                }
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                for (int k = 0; k < enemies.Count; k++)
                {
                    if (enemies[k].x < this.ClientSize.Width && bullets[i].x >= enemies[k].x && bullets[i].x < enemies[k].x + 50 && heros[0].y >= 650)
                    {
                        enemies.Remove(enemies[k]);
                        bullets.Remove(bullets[i]);
                    }
                }

            }
            if (bosses[0].health <= 0)
            {

            }
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].x >= bosses[0].x && heros[0].x > this.ClientSize.Width / 2 && ct == 0 && heros[0].x > this.ClientSize.Width / 2)
                {
                    bullets.Remove(bullets[i]);
                    bosses[0].health -= 10;
                }
            }

            countTick++;
            Graphics g = this.CreateGraphics();
            DB();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                bullet pnn = new bullet();
                pnn.im = new Bitmap("bullet.jpg");
                pnn.im.MakeTransparent(pnn.im.GetPixel(0, 0));
                pnn.x = guns[0].x + 10;
                pnn.y = guns[0].y + 20;
                bullets.Add(pnn);
            }
            if (e.KeyCode == Keys.Up)
            {
                ct2 = 1;
                heros[0].im = new Bitmap("mariosup.png");
                heros[0].im.MakeTransparent(heros[0].im.GetPixel(0, 0));


            }
            if (e.KeyCode == Keys.Left)
            {

                if (heros[0].x > 100)
                {
                    if (ct == 1)
                    {
                        for (int n = 0; n < boxes.Count; n++)
                        {
                            boxes[n].x += 20;
                        }
                        for (int i = 0; i < enemies.Count; i++)
                        {
                            enemies[i].x += 10;


                        }
                        for (int k = 0; k < blocks.Count; k++)
                        {
                            blocks[k].x += 20;
                        }
                    }
                    if (ct == 0)
                    {
                        heros[0].x -= 20;
                        guns[0].x -= 20;
                        if (heros[0].x >= this.ClientSize.Width / 2 - 100 && heros[0].x < this.ClientSize.Width / 2)
                        {
                            ct = 1;
                        }
                    }
                    if (ct == 1 && move > 0)
                    {
                        move -= 5;
                        move2 -= 5;
                    }
                    else
                    {
                        ct = 0;
                    }
                    if (c >= 12)
                    {
                        c = 0;
                    }
                    c++;
                    heros[0].im = new Bitmap("marios" + c + ".png");
                    heros[0].im.MakeTransparent(heros[0].im.GetPixel(0, 0));


                }


            }
            if (e.KeyCode == Keys.Enter)
            {
                st = 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (heros[0].x < 1400)
                {
                    if (ct == 1)
                    {

                        for (int k = 0; k < blocks.Count; k++)
                        {
                            blocks[k].x -= 20;
                        }
                        for (int i = 0; i < enemies.Count; i++)
                        {
                            enemies[i].x -= 10;

                        }
                        for (int n = 0; n < boxes.Count; n++)
                        {
                            boxes[n].x -= 20;
                        }
                    }
                    if (ct == 0)
                    {
                        heros[0].x += 30;
                        guns[0].x += 30;
                        if (heros[0].x >= this.ClientSize.Width / 2 - 100 && heros[0].x < this.ClientSize.Width / 2)
                        {
                            ct = 1;
                        }
                    }
                    if (ct == 1 && move2 < 700)
                    {
                        move += 5;
                        move2 += 5;
                    }
                    else
                    {
                        ct = 0;
                    }

                    if (c >= 12)
                    {
                        c = 0;
                    }
                    c++;
                    heros[0].im = new Bitmap("marios" + c + ".png");
                    heros[0].im.MakeTransparent(heros[0].im.GetPixel(0, 0));

                }
            }
        }

        private void Form1_Load1(object sender, EventArgs e)
        {

            rnd = new Random();
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            back pnn = new back();

            pnn.im = new Bitmap("background0.GIF");
            backgrounds.Add(pnn);
            hero sol = new hero();
            sol.x = 100;
            sol.y = 715;
            sol.im = new Bitmap("marios" + c + ".png");
            sol.im.MakeTransparent(sol.im.GetPixel(0, 0));
            hw = sol.im.Width + 70;
            hh = sol.im.Height + 70;
            heros.Add(sol);
            gun pnm = new gun();
            pnm.im = new Bitmap("gun.png");
            pnm.x = 160;
            pnm.y = 740;
            guns.Add(pnm);
            elevator oo = new elevator();
            oo.x = 600;
            oo.y = 100;
            oo.im = new Bitmap("blocks.png");
            elevators.Add(oo);
            int v = 300;
            rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                block pss = new block();
                pss.im = new Bitmap("blocks.png");
                pss.im.MakeTransparent(pss.im.GetPixel(0, 0));
                pss.x = v;
                pss.y = 550;

                blocks.Add(pss);
                v += rnd.Next(400, 1000);

            }
            v = 100;
            for (int i = 0; i < 2; i++)
            {
                box pnl = new box();
                pnl.im = new Bitmap("goldblock.png");
                pnl.x = v;
                pnl.y = 550;
                boxes.Add(pnl);
                v += 400;
            }

            boss pnd = new boss();
            pnd.x = 1400;
            pnd.y = 700;
            pnd.im = new Bitmap("dragon.png");
            pnd.im.MakeTransparent(pnd.im.GetPixel(0, 0));
            pnd.health = 500;
            bosses.Add(pnd);






        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DB();
        }

        void draw(Graphics g2)
        {

            g2.Clear(Color.SkyBlue);
            Rectangle rcD;
            Rectangle rcS;
            rcD = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            rcS = new Rectangle(move, 0, move2, backgrounds[0].im.Height);
            g2.DrawImage(backgrounds[0].im, rcD, rcS, GraphicsUnit.Pixel);
            if (st == 1)
            {
                for (int i = 0; i < enemybullets.Count; i++)
                {
                    rcD = new Rectangle(enemybullets[i].x, enemybullets[i].y, 50, 50);
                    rcS = new Rectangle(0, 0, enemybullets[i].im.Width, enemybullets[i].im.Height);
                    g2.DrawImage(enemybullets[i].im, rcD, rcS, GraphicsUnit.Pixel);

                }
                if (heros[0].x > this.ClientSize.Width / 2)
                {
                    rcD = new Rectangle(bosses[0].x - 150, bosses[0].y - 150, 300, 300);
                    rcS = new Rectangle(0, 0, bosses[0].im.Width, bosses[0].im.Height);
                    g2.DrawImage(bosses[0].im, rcD, rcS, GraphicsUnit.Pixel);
                }


                rcD = new Rectangle(heros[0].x, heros[0].y - 10, hw, hh);
                rcS = new Rectangle(0, 5, heros[0].im.Width, heros[0].im.Height);
                g2.DrawImage(heros[0].im, rcD, rcS, GraphicsUnit.Pixel);
                rcD = new Rectangle(guns[0].x, guns[0].y, 50, 50);
                rcS = new Rectangle(0, 0, guns[0].im.Width, guns[0].im.Height);
                if (c % 2 == 0)
                {
                    g2.DrawImage(guns[0].im, rcD, rcS, GraphicsUnit.Pixel);
                }
                for (int i = 0; i < enemies.Count; i++)
                {
                    rcD = new Rectangle(enemies[i].x, enemies[i].y, 70, 70);
                    rcS = new Rectangle(0, 0, enemies[0].im.Width, enemies[0].im.Height);
                    g2.DrawImage(enemies[i].im, rcD, rcS, GraphicsUnit.Pixel);
                }
                for (int i = 0; i < bullets.Count; i++)
                {
                    rcD = new Rectangle(bullets[i].x, bullets[i].y, 10, 10);
                    rcS = new Rectangle(0, 0, bullets[0].im.Width, bullets[0].im.Height);
                    g2.DrawImage(bullets[i].im, rcD, rcS, GraphicsUnit.Pixel);
                }
                for (int i = 0; i < blocks.Count; i++)
                {
                    rcD = new Rectangle(blocks[i].x, blocks[i].y, 200, 70);
                    rcS = new Rectangle(0, 0, blocks[0].im.Width, blocks[0].im.Height);
                    g2.DrawImage(blocks[i].im, rcD, rcS, GraphicsUnit.Pixel);

                }
                for (int i = 0; i < boxes.Count; i++)
                {
                    rcD = new Rectangle(boxes[i].x, boxes[i].y, 100, 70);
                    rcS = new Rectangle(0, 0, boxes[0].im.Width, boxes[0].im.Height);
                    g2.DrawImage(boxes[i].im, rcD, rcS, GraphicsUnit.Pixel);
                }
                for (int i = 0; i < gifts.Count; i++)
                {
                    rcD = new Rectangle(gifts[i].x, gifts[i].y, 50, 50);
                    rcS = new Rectangle(0, 0, gifts[0].im.Width, gifts[0].im.Height);
                    g2.DrawImage(gifts[i].im, rcD, rcS, GraphicsUnit.Pixel);

                }
                // Create font and brush.
                Font drawFont = new Font("Bold", 20);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                // Create point for upper-left corner of drawing.
                PointF drawPoint = new PointF(100, 100);
                PointF draw = new PointF(400, 100);

                // Draw string to screen.
                g2.DrawString("Lives " + lives, drawFont, drawBrush, drawPoint);
                if (heros[0].x > this.ClientSize.Width / 2)
                {
                    g2.DrawString("Dragon HP " + bosses[0].health, drawFont, drawBrush, draw);
                }

            }
            if (st == 0)
            {

                // Create font and brush.
                Font Font = new Font("Times New Roman", 180, FontStyle.Italic);
                SolidBrush Brush = new SolidBrush(Color.DarkRed);

                // Create point for upper-left corner of drawing.
                PointF Point = new PointF(80, 200);

                // Draw string to screen.
                g2.DrawString("Super Mario", Font, Brush, Point);
                rcD = new Rectangle(this.ClientSize.Width / 2 - 100, heros[0].y - 80, hw + 100, hh + 100);
                rcS = new Rectangle(0, 5, heros[0].im.Width, heros[0].im.Height);
                g2.DrawImage(heros[0].im, rcD, rcS, GraphicsUnit.Pixel);
            }
        }
        void DB()
        {
            Graphics g2 = Graphics.FromImage(off);
            draw(g2);


            Graphics g = this.CreateGraphics();
            g.DrawImage(off, 0, 0);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
