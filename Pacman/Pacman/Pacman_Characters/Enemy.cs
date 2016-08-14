namespace Pacman.Characters
{
    public delegate void Enemy_Movement(object sender,System.Drawing.Point location);
    public delegate void Enemy_PacmanCatched(object sender);

    public class Enemy : System.Windows.Forms.Control, ICharacter
    {
        public event Enemy_Movement Enemy_Movement;
        public event Enemy_PacmanCatched Enemy_PacmanCatched;

        Pacman _pacman = null;
        CharacterType m_Type = CharacterType.Enemy;
        int m_Speed = 20;
        public Enemy()
        {
            this.Height = this.Width = 40;
        }

        public Enemy(Characters.Pacman pacman)
            :this()
        {
            _pacman = pacman;
            Enemy_Movement += new Characters.Enemy_Movement(Enemy_Enemy_Movement);
        }

        void Enemy_Enemy_Movement(object sender, System.Drawing.Point location)
        {
            if (_pacman.Location == location)
            {
                if (Enemy_PacmanCatched != null)
                    Enemy_PacmanCatched(this);

                _pacman.Catched(this);
            }
        }

        public CharacterType Type
        {
            get { return m_Type; }
        }

        public new void Move(MovementWay way)
        {
            switch (way)
            {
                case MovementWay.Up:
                    this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y - Speed);
                    break;

                case MovementWay.Down:
                    this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y + Speed);
                    break;

                case MovementWay.Left:
                    this.Location = new System.Drawing.Point(this.Location.X - Speed, this.Location.Y);
                    break;

                case MovementWay.Right:
                    this.Location = new System.Drawing.Point(this.Location.X + Speed, this.Location.Y);
                    break;
            }

            if (_pacman != null)
            {
                Enemy_Movement(this, this.Location);
                return;
            }

            if (Enemy_Movement != null)
                Enemy_Movement(this, this.Location);

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            DrawCharacter.Draw(ref e, Type);

            base.OnPaint(e);
        }

        public int TotalPoints
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public int Speed
        {
            get
            {
                return m_Speed;
            }
            set
            {
                m_Speed = value;
            }
        }
    }
}
