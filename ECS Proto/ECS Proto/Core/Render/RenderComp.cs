using ECS_Proto.Core.Component;
using OpenTK.Graphics;

namespace ECS_Proto.Core.Render
{
    class RenderComp : IComponent
    {
        public char Char = '?';
        public Color4 Foreground = Color4.White;
        public Color4 Background = Color4.Black;
    }
}
