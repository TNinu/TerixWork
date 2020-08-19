using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Tetris
{
    class CreateShape
    {
        public static BaseShape Create() {
            switch (GetRandom())
            {
                case (int)ShapeType.Shape_i:
                    return new Shape_i();
                case (int)ShapeType.Shape_L:
                    return new Shape_L();
                case (int)ShapeType.Shape_o:
                    return new Shape_o();
                case (int)ShapeType.Shape_w:
                    return new Shape_w();
                case (int)ShapeType.Shape_z1:
                    return new Shape_z1();
                case (int)ShapeType.Shape_z2:
                    return new Shape_z2();
                default:
                    break;
            }
            return null;
        }
        public static int GetRandom()
        {
            Random random = new Random();
            return random.Next(0, 6);
        }
    }
}
