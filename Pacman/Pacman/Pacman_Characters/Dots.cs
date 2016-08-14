namespace Pacman.Characters
{
    public class Dots:System.Windows.Forms.Control , IDots
    {
        int _points = 100;
        System.Drawing.Color m_Color = System.Drawing.Color.Blue;
        public Dots()
        {
            this.Width = this.Height = 30;
        }

        public Dots(int point)
            : this()
        {
            _points = point;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.Pen p = new System.Drawing.Pen(Dot_Color);
            e.Graphics.FillEllipse(p.Brush,15,15,10,10);

            base.OnPaint(e);
        }

        public int Points
        {
            get { return _points ; }
        }

        public System.Drawing.Color Dot_Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public new void Dispose()
        {
            _points = 0;
            this.Dispose(true);
        }

    }
}
