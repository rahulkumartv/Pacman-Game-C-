
namespace Pacman.Characters
{
    public class Block:System.Windows.Forms.Control,IBlock
    {
        System.Drawing.Color m_Block_Color = System.Drawing.Color.Brown;
        public Block()
        {
            this.BackColor = Block_Color;
        }

        public Block(int width, int height)
            : this()
        {
            this.Width = width;
            this.Height = height;
        }

        public Block(int width, int height, System.Drawing.Point location)
            : this(width,height)
        {
            this.Location = location;
        }

        public System.Drawing.Color Block_Color
        {
            get
            {
                return m_Block_Color;
            }
            set
            {
                m_Block_Color = value;
            }
        }
    }
}
