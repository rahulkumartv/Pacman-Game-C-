using System;

namespace Pacman.Characters
{
    public interface IBlock:IDisposable
    {
        System.Drawing.Color Block_Color { get; set; }
    }
}
