using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Starwalle
{
    public partial class Form1 : Form
    {
        List<MoveableItem> items = new List<MoveableItem>();
        List<MoveableItem> items2 = new List<MoveableItem>();
        List<MoveableItem> itemsToBeAdded = new List<MoveableItem>();
        PictureBox[] healthArray = new PictureBox[3];
        const int speed = 10;
        Timer Clock = new Timer();
        Timer EnemyClock = new Timer();
        Stopwatch watch = new Stopwatch();
        Random random = new Random();
        public static MoveableItem playerBox;
        public static MoveableItem holderBox;
        public static PictureBox holderPicture;
        bool listSwitch = true;
        int shotCooldown = 500;
        long timeHolder = 0;
        public static bool GameOver = false;
        public bool isSheilded;
        public float sheildTimeHolder = 0;
        public float sheildTimeLeft = 0;
        public int sheildDuration = 2000;
        public int sheildCooldown = 10000;

        void moveItems(Object obj, EventArgs e)
        {
            if (GameOver == false)
            {
                if (listSwitch == true)
                {
                    for (int i = 0; i < itemsToBeAdded.Count; i++)
                    {
                        items.Add(itemsToBeAdded.ElementAt(i));
                    }
                    itemsToBeAdded.Clear();
                    items2.Clear();

                    for (int i = 0; i < items.Count; i++)
                    {
                        items2.Add(items.ElementAt(i));
                    }

                    foreach (MoveableItem i in items)
                    {
                        if (i.isDead)
                            items2.Remove(i);
                        else if (i.picture.Location.Y > 800 || i.picture.Location.Y < 10 || i.picture.Location.X > 1250 || i.picture.Location.X < 0)
                        {
                            this.Controls.Remove(i.picture);
                            items2.Remove(i);
                            i.isDead = true;
                        }
                        i.Move();
                        sheildPicture.Location = new Point(player.Location.X - 64, sheildPicture.Location.Y);
                        if(!i.isPlayer && i.HasBounds && !i.isDead)
                        {
                            EnemyFire(i);
                        }
                        if (i.isBullet)
                        {
                            foreach (MoveableItem j in items)
                            {
                                if (!i.isDead && !j.isDead && i.rectangle.IntersectsWith(j.rectangle) && !i.Equals(j) && !j.Equals(playerBox))
                                {
                                        i.Die();
                                        j.Die();
                                        this.Controls.Remove(i.picture);
                                        items2.Remove(i);
                                        this.Controls.Remove(j.picture);
                                        items2.Remove(j);
                                }
                            }
                        }
                        if (!i.Equals(playerBox) && i.rectangle.IntersectsWith(playerBox.rectangle) && isSheilded == false)
                        {
                            GameOverTransisiton(i);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < itemsToBeAdded.Count; i++)
                    {
                        items2.Add(itemsToBeAdded.ElementAt(i));
                    }
                    itemsToBeAdded.Clear();
                    items.Clear();

                    for (int i = 0; i < items.Count; i++)
                    {
                        items.Add(items.ElementAt(i));
                    }
                    foreach (MoveableItem i in items2)
                    {
                        if (i.isDead)
                            items.Remove(i);
                        else if (i.picture.Location.Y > 800 || i.picture.Location.Y < -10 || i.picture.Location.X > 1250 || i.picture.Location.X < 20)
                        {
                            this.Controls.Remove(i.picture);
                            items.Remove(i);
                            i.Die();
                        }
                        i.Move();
                        sheildPicture.Location = new Point(player.Location.X - 64, sheildPicture.Location.Y);
                        if (!i.isPlayer && i.HasBounds && !i.isDead)
                        {
                            EnemyFire(i);
                        }
                        if (i.isBullet)
                        {
                            foreach (MoveableItem j in items2)
                            {
                                if (!i.isDead && !j.isDead && i.rectangle.IntersectsWith(j.rectangle) && !i.Equals(j) && !j.Equals(playerBox))
                                {
                                    i.Die();
                                    j.Die();
                                    this.Controls.Remove(i.picture);
                                    items.Remove(i);
                                    this.Controls.Remove(j.picture);
                                    items.Remove(j);
                                }
                            }
                        }
                            if (!i.Equals(playerBox) && i.rectangle.IntersectsWith(playerBox.rectangle) && isSheilded == false)
                        {
                            GameOverTransisiton(i);
                        }
                    }

                }
                if (sheildTimeLeft < watch.ElapsedMilliseconds)
                {
                    isSheilded = false;
                    DoShield();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            Clock.Interval = 25;
            Clock.Tick += new EventHandler(moveItems);
            Clock.Start();
            EnemyClock.Interval = 4000;
            EnemyClock.Tick += new EventHandler(SpawnEnemy);
            EnemyClock.Start();
            watch.Start();
            playerBox = new MoveableItem(0, 0, true, false, true, player);
            holderPicture = player;
            holderBox = playerBox;
            items.Insert(0, playerBox);
            gameOverText.Enabled = false;
            healthArray[0] = Lifebox1;
            healthArray[1] = Lifebox2;
            healthArray[2] = Lifebox3;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        { }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /*
         * When the user presses a specific key down, the action happens.
         * RIGHT/LEFT - the player is added to the list at index 0 with its speed going in the specified direction.
         *              When the player releases the key, they are removed from the list.
         * Spacebar - the player shoots a bullet toward the enemy. Bullet creation is just making a picturebox that 
         *            is red, and adding it to a MoveableItem, which is then added to the next list to move items.
         * Z - The player creates a sheild around them, preventing them from taking damage while it is up.
         *     The sheild is just a picturebox, and a boolean value is activated for the duration. 
         *     Once the time specified is over, the sheild fades.
         * R - Once the game is over, the user can press R to restart.
         */

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                MoveableItem temp = items.First();
                temp.Xspeed = speed;
                items.RemoveAt(0);
                items.Insert(0, temp);
            }

            if (e.KeyCode == Keys.Left)
            {
                MoveableItem temp = items.First();
                temp.Xspeed = -speed;
                items.RemoveAt(0);
                items.Insert(0, temp);
            }

            if (e.KeyCode == Keys.Up)
            {
                MoveableItem temp = items.First();
                temp.Yspeed = -speed;
                items.RemoveAt(0);
                items.Insert(0, temp);
            }

            if (e.KeyCode == Keys.Down)
            {
                MoveableItem temp = items.First();
                temp.Yspeed = speed;
                items.RemoveAt(0);
                items.Insert(0, temp);
            }
            if (e.KeyCode == Keys.Space)
            {
                if (timeHolder < watch.ElapsedMilliseconds)
                {
                    timeHolder = watch.ElapsedMilliseconds + shotCooldown;
                    PictureBox clone = new PictureBox();
                    clone.Width = 40;
                    clone.Height = 40;
                    clone.Location = new Point(playerBox.picture.Location.X + (playerBox.picture.Width/2) - (clone.Width/2), playerBox.picture.Location.Y - 25 - playerBox.picture.Height);
                    clone.BackColor = Color.Red;
                    MoveableItem bullet = new MoveableItem(0, -10, false, true, false, clone);
                    items.Add(bullet);
                    this.Controls.Add(clone);
                }
                else
                    Debug.WriteLine(watch.ElapsedMilliseconds);

            }

            if (e.KeyCode == Keys.Z)
            {
                if (sheildTimeHolder < watch.ElapsedMilliseconds)
                {
                    sheildTimeHolder = watch.ElapsedMilliseconds + sheildCooldown;
                    sheildTimeLeft = watch.ElapsedMilliseconds + sheildDuration;
                    isSheilded = true;
                    DoShield();
                }
                else
                    Debug.WriteLine(watch.ElapsedMilliseconds);

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                MoveableItem temp = items.First();
                temp.Xspeed = 0;
                items.RemoveAt(0);
                items.Insert(0, temp);
            }

            if (e.KeyCode == Keys.Left)
            {
                MoveableItem temp = items.First();
                temp.Xspeed = 0;
                items.RemoveAt(0);
                items.Insert(0, temp);
            }

            if (e.KeyCode == Keys.Up)
            {
                MoveableItem temp = items.First();
                temp.Yspeed = 0;
                items.RemoveAt(0);
                items.Insert(0, temp);
            }

            if (e.KeyCode == Keys.Down)
            {

            }

            if (e.KeyCode == Keys.R && GameOver == true)
            {
                Restart();
            }
        }

        private void player_Click(object sender, EventArgs e)
        {

        }


        void SpawnEnemy(Object obj, EventArgs e)
        {
            Debug.WriteLine("SpawnEnemy");
            for (int i = 0; i < random.Next(1, 3); i++)
            {
                timeHolder = watch.ElapsedMilliseconds + shotCooldown;
                PictureBox clone = new PictureBox();
                clone.BackgroundImage = enemyPicture.BackgroundImage;
                clone.BackgroundImageLayout = enemyPicture.BackgroundImageLayout;

                clone.Width = 50;
                clone.Height = 50;
                clone.Location = new Point(random.Next(0, 1150), random.Next(10, 300));
                int speed = random.Next(-2, 2);
                if (speed != 0)
                {
                    MoveableItem bullet = new MoveableItem(speed, 0, true, false, false, clone);
                    items.Add(bullet);
                    this.Controls.Add(clone);

                }
                else
                {
                    MoveableItem bullet = new MoveableItem(1, 0, true, false, false, clone);
                    items.Add(bullet);
                    this.Controls.Add(clone);
                }
            }
           
        }

        void EnemyFire(MoveableItem enemy)
        {
            if (enemy.shotCooldown < watch.ElapsedMilliseconds)
            {
                enemy.shotCooldown = watch.ElapsedMilliseconds + 1500;
                PictureBox clone = new PictureBox();
                clone.Width = 10;
                clone.Height = 10;
                clone.Location = new Point(enemy.picture.Location.X + enemy.picture.Width/2, enemy.picture.Location.Y + 15 + enemy.picture.Height);
                clone.BackColor = Color.Red;
                MoveableItem bullet = new MoveableItem(0, 5, false, true, false, clone);
                itemsToBeAdded.Add(bullet);
                this.Controls.Add(clone);
            }
        }

        void GameOverTransisiton(MoveableItem i)
        {
            i.Die();
            i.picture.Dispose();
            
            Debug.WriteLine("Hit");
            playerBox.playerHealth--;
            if(playerBox.playerHealth < 0)
                playerBox.playerHealth = 0;
            healthArray[playerBox.playerHealth].Visible = false;
            if (playerBox.playerHealth <= 0)
            {
                gameOverText.Visible = true;
                GameOver = true;
                Debug.WriteLine("GAMEOVER");
                EnemyClock.Stop();
                Clock.Stop();
                watch.Stop();
            }
        }

        void Restart()
        {
            
            for (int i = 0; i < items2.Count; i++)
            {
                MoveableItem[] temp = items2.ToArray();
                items2.Clear();
                if (!temp[i].isPlayer && !i.Equals(gameOverText) && !i.Equals(healthArray[0]) && !i.Equals(healthArray[1]) && !i.Equals(healthArray[2]))
                {
                    temp[i].picture.Dispose();
                    temp[i].rectangle.Location = new Point(2000, 2000);
                }
                items2 = temp.ToList<MoveableItem>();
            }

            for (int i = 0; i < items.Count; i++)
            {
                MoveableItem[] temp = items.ToArray();
                items.Clear();
                if (!temp[i].isPlayer && !i.Equals(gameOverText) && !i.Equals(healthArray[0]) && !i.Equals(healthArray[1]) && !i.Equals(healthArray[2]))
                {
                    temp[i].picture.Dispose();
                    temp[i].rectangle.Location = new Point(2000, 2000);
                }
                items = temp.ToList<MoveableItem>();
            }

            for (int i = 0; i < itemsToBeAdded.Count; i++)
            {
                MoveableItem[] temp = itemsToBeAdded.ToArray();
                itemsToBeAdded.Clear();
                if (!i.Equals(player) && !i.Equals(playerBox) && !i.Equals(gameOverText) && !i.Equals(healthArray[0]) && !i.Equals(healthArray[1]) && !i.Equals(healthArray[2]))
                {
                    temp[i].picture.Location = new Point(2000, 2000);
                    temp[i].rectangle.Location = new Point(2000, 2000);
                }
                itemsToBeAdded = temp.ToList<MoveableItem>();
            }

            listSwitch = true;
            GameOver = false;
            gameOverText.Visible = false;
            healthArray[0].Visible = true;
            healthArray[1].Visible = true;
            healthArray[2].Visible = true;
            playerBox = holderBox;
            playerBox.picture = holderPicture;
            playerBox.playerHealth = 3;
            playerBox.picture.Location = new Point(503, 619);
            playerBox.rectangle.Location = new Point(503, 619);
            watch.Restart();
            watch.Start();
            EnemyClock.Start();
            Clock.Start();
            if (gameOverText.Visible == true)
                gameOverText.Visible = false;
        }

        void DoShield()
        {
            if(isSheilded == true)
            {
                sheildPicture.Visible = true;
            }
            else
            {
                sheildPicture.Visible = false;
            }
        }

        void Destroy(MoveableItem o)
        {
            Controls.Remove(o.picture);
            o.picture.Dispose();
        }

        private void gameOverText_TextChanged(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }

    
}

public class MoveableItem
{
    public int Yspeed { get; set; }
    public int Xspeed { get; set; }
    public PictureBox picture;
    public bool HasBounds { get; } 
    public bool isBullet { get; }
    public bool isPlayer { get; }
    public bool isDead = false;
    int holder;
    public Rectangle rectangle;
    public float shotCooldown { get; set; }
    public int playerHealth = 3;


    public MoveableItem(int Xspeed, int Yspeed, bool HasBounds, bool isBullet, bool isPlayer, PictureBox picture)
    {
        this.Yspeed = Yspeed;
        this.Xspeed = Xspeed;
        this.picture = picture;
        this.HasBounds = HasBounds;
        this.isBullet = isBullet;
        this.isPlayer = isPlayer;
        shotCooldown = 0;
        rectangle = new Rectangle(picture.Location.X, picture.Location.Y, picture.Width, picture.Height);
    }

    public void Move()
    {
        if (isDead == false)
        {
            if (HasBounds && !isPlayer)
            {
                picture.Location = new Point(picture.Location.X + Xspeed, picture.Location.Y);
                if (picture.Location.X > 1100 - picture.Width)
                {
                    picture.Location = new Point(1100 - picture.Width, picture.Location.Y);
                    Xspeed = -Xspeed;
                }
                if (picture.Location.X < 100)
                {
                    picture.Location = new Point(100, picture.Location.Y);
                    Xspeed = -Xspeed;
                }
            }
            else if (HasBounds && isPlayer)
            {
                picture.Location = new Point(picture.Location.X + Xspeed, picture.Location.Y);
                if (picture.Location.X > 1200 - picture.Width)
                {
                    picture.Location = new Point(1200 - picture.Width, picture.Location.Y);
                }
                if (picture.Location.X < 0)
                {
                    picture.Location = new Point(0, picture.Location.Y);
                }
            }
            else
            {
                picture.Location = new Point(picture.Location.X + Xspeed, picture.Location.Y + Yspeed);
                if (picture.Location.Y < -10 || picture.Location.Y > 800)
                {
                    Die();
                }
            }

            rectangle.Location = picture.Location;
        }
    }

    public void Die()
    {
        isDead = true;
        picture.Dispose();
        rectangle.Location = new Point(2000, 2000);
    }

}
