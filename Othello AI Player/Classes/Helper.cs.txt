using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_AI_Player
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };

    public enum Position_Color
    {
        BLACK,
        WHITE,
        EMPTY
    }

    internal class Helper
    {
        public const int board_size = 8;
    }
}
