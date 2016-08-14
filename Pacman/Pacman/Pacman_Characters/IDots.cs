using System;

namespace Pacman.Characters
{
    public interface IDots:IDisposable
    {
        int Points { get; }
        System.Drawing.Color Dot_Color { get; set; }
    }
}
