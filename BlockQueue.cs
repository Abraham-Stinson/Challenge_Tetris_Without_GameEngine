using System;
using System.Windows.Documents;

namespace GridGameProject.GameLogic
{
    public class BlockQueue
    {
        private readonly Random random = new Random();

        public Block GetRandomBlock()
        {
            int index = random.Next(5);

            switch (index)
            {
                case 0: return new T_Block();
                case 1: return new I_Block();
                case 2: return new O_Block();
                case 4: return new L_Block();
                case 5: return new Z_Block();

                default: return new T_Block();
            }
        }
    }
}