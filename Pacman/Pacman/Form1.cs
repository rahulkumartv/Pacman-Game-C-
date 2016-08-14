using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private readonly int PacGrpMargin = 40;
        private readonly int PacBoxMar = 20;
        private List<Characters.Dots> dotsList = new List<Characters.Dots>();
        private List<Characters.Block> blocksList = new List<Characters.Block>();
        private int outerBoxWidth;
        private int outerBoxHeight;
        Characters.Enemy packmanEnemy;
        Characters.MovementWay enemyMove;
        Characters.Pacman packman;
        public Form1()
        {
            InitializeComponent();
            
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;
            const int WM_NCLBUTTONDBLCLK = 0x00A3; 
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                       return;
                    break;
            }

            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    packman.Move(Characters.MovementWay.Left);
                    break;
                case Keys.Right:
                    packman.Move(Characters.MovementWay.Right);
                    
                    break;
                case Keys.Up:
                    packman.Move(Characters.MovementWay.Up);
                    break;
                case Keys.Down:
                    packman.Move(Characters.MovementWay.Down);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PacmanBox.Width = this.Width - PacGrpMargin;
            PacHeaderBox.Width = this.Width - PacGrpMargin;
            PacHeaderBox.Top = this.Bottom - PacHeaderBox.Height- PacGrpMargin;
            PacmanBox.Height = PacHeaderBox.Top;
            GameStart.Left = PacHeaderBox.Width - GameStart.Width - PacGrpMargin;
            GameStart.Enabled = true;
            outerBoxWidth = PacmanBox.Width - PacmanBox.Width % 40;
            outerBoxHeight = PacmanBox.Height - PacmanBox.Height % 40 - PacBoxMar;
            this.timer1.Tick += new System.EventHandler(timer1_Tick);
        }

        private void GameStart_Click(object sender, EventArgs e)
        {
            this.PacmanBox.Controls.Clear();
            this.PacmanBox.Refresh();
            dotsList.Clear();
            blocksList.Clear();
            if (packman != null)
            {
                packman.Dispose();
            }
            if (packmanEnemy != null)
            {
                packmanEnemy.Dispose();
            }
            GameInitialization();
            GameStart.Enabled = false;
            this.Focus();
            this.Activate();
            this.Select();
        }

        private void GameInitialization()
        {
            ScoreLabel.Text = "0";
            LoadBlocks();
            LoadDots();
            packman = new Characters.Pacman( dotsList.ToArray(), blocksList.ToArray());
            packman.Pacman_PointsChanged += new Characters.Pacman_PointsChanged(pack_Pacman_PointsChanged);
            packman.Pacman_Messages += new Characters.Pacman_Messages(pack_Pacman_Messages);
            packman.Location = new Point(100, 100);
            this.PacmanBox.Controls.Add(packman);
            this.PacmanBox.Controls.AddRange(blocksList.ToArray());
            this.PacmanBox.Controls.AddRange(dotsList.ToArray());
            StartTimer();
        }

        void LoadBlocks()
        {
            
            Characters.Block top = new Characters.Block(outerBoxWidth, 20, new Point(20, 20));
            blocksList.Add(top);
            Characters.Block left = new Characters.Block(20, outerBoxHeight, new Point(20, 20));
            blocksList.Add(left);
            Characters.Block right = new Characters.Block(20, outerBoxHeight, new Point(outerBoxWidth,20));
            blocksList.Add(right);
            Characters.Block down = new Characters.Block(outerBoxWidth, 20, new Point(20, outerBoxHeight));
            blocksList.Add(down);
            int nIdx = 4;
            int nYaxisLimit = PacGrpMargin * 2;
            
            for (; nYaxisLimit < outerBoxHeight- PacGrpMargin;)
            {               
                int nXaxisLimit = PacGrpMargin*2;
                for (; nXaxisLimit < outerBoxWidth; nIdx++)
                {
                    
                    if( (outerBoxWidth - nXaxisLimit) > 100)
                    {
                        Characters.Block block = new Characters.Block(100, 20, new Point(nXaxisLimit, nYaxisLimit));
                        blocksList.Add(block);
                    }
                    nXaxisLimit += 100 + PacGrpMargin;
                }
                nYaxisLimit += PacGrpMargin*2-20;
            }

            
        }

        void LoadDots()
        {
            
            int nIdx=0;
            int nYaxis = 40;
            for (; nYaxis < PacmanBox.Height - PacGrpMargin * 2; nYaxis += PacGrpMargin+20)
            {
                int nLimit = 40;
                for (; nLimit < PacmanBox.Width - PacBoxMar * 2 - 20; nIdx++, nLimit += 40)
                {
                    if (( PacmanBox.Width - PacBoxMar * 2) -nLimit > 20)
                    {

                        Characters.Dots dot = new Characters.Dots();
                        dot.Location = new Point(nLimit, nYaxis);
                        dotsList.Add(dot);
                    }
                }
            }
            nYaxis = 70;
            for (; nYaxis < PacmanBox.Height - PacGrpMargin * 2; nYaxis += PacGrpMargin + 20)
            {
                int nLimit = 40;
                for (; nLimit < PacmanBox.Width - PacBoxMar * 2 - 20; nIdx++, nLimit += 140)
                {
                    if ((PacmanBox.Width - PacBoxMar * 2) - nLimit > 20)
                    {
                        Characters.Dots dot = new Characters.Dots();
                        dot.Location = new Point(nLimit, nYaxis);
                        dotsList.Add(dot);
                    }
                }
            }


        }

        void pack_Pacman_Messages(object sender, string messages)
        {
           
            timer1.Stop();
            MessageBox.Show(messages);
            GameStart.Enabled = true;
        }
        void pack_enemy_catched(object sender)
        {
            packman.BringToFront();
            packman.Refresh();
            timer1.Stop();
            GameStart.Enabled = true;
        }
        void pack_Pacman_PointsChanged(object sender, int totalPoints)
        {
            ScoreLabel.Text = totalPoints.ToString();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (enemyMove == Characters.MovementWay.Right)
            {
                if (packmanEnemy.Location.X >= outerBoxWidth - 80)
                {
                    timer1.Enabled = false;
                    timer1.Stop();
                    packmanEnemy.Dispose();
                    StartTimer();
                }
                else
                {
                    packmanEnemy.Move(Characters.MovementWay.Right);
                }
            }
            if (enemyMove == Characters.MovementWay.Down )
            {
                if (packmanEnemy.Location.Y >= outerBoxHeight - 80)
                {
                    timer1.Enabled = false;
                    timer1.Stop();
                    packmanEnemy.Dispose();
                    StartTimer();
                }
                else
                {
                    packmanEnemy.Move(Characters.MovementWay.Down);
                }
            }

            if (enemyMove == Characters.MovementWay.Up)
            {
                if (packmanEnemy.Location.Y <= 80)
                {
                    timer1.Enabled = false;
                    timer1.Stop();
                    packmanEnemy.Dispose();
                    StartTimer();
                }
                else
                {
                    packmanEnemy.Move(Characters.MovementWay.Up);
                }
            }
            if (enemyMove == Characters.MovementWay.Left)
            {
                if (packmanEnemy.Location.X <= 80)
                {
                    timer1.Enabled = false;
                    timer1.Stop();
                    packmanEnemy.Dispose();
                    StartTimer();
                }
                else
                {
                    packmanEnemy.Move(Characters.MovementWay.Left);
                }
            }
        }

        void StartTimer()
        {
            packmanEnemy = new Characters.Enemy(packman);


            packmanEnemy.Location = new Point(outerBoxWidth/2-20, 40);
            packmanEnemy.Enemy_PacmanCatched += new Characters.Enemy_PacmanCatched(pack_enemy_catched);
            this.PacmanBox.Controls.Add(packmanEnemy);
            packmanEnemy.BringToFront();
            Characters.MovementWay newMove = enemyMove;
            while (newMove == enemyMove)
            {             

                enemyMove = GenerateEnemyMove();
            } 
            this.timer1.Interval = 200;
            this.timer1.Enabled = true;
        }

        Characters.MovementWay GenerateEnemyMove()
        {
            Array  moveArray = Enum.GetValues(typeof(Characters.MovementWay));
            return (Characters.MovementWay )moveArray.GetValue(new Random().Next(moveArray.Length));
        }
    }
}
