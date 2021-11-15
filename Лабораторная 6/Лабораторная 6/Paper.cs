using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_6
{
    public sealed class Paper
    {
        public string Color { set; get; }
        public bool HasUniqueStyle { set; get; }
        public bool IsTransparent { set; get; }
        public Paper(string color)
        {
            Color = color;
            HasUniqueStyle = true;
            IsTransparent = false;
        }

        public override string ToString()
        {
            return $"{GetType()} {Color} {HasUniqueStyle} {IsTransparent}";
        }
    }
}
