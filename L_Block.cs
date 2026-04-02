using System;

namespace GridGameProject.GameLogic
{
    public class L_Block : Block
    {
        public L_Block() : base(
            new bool[,]
            {
                {false,false,false},
                {true,false,false},
                {true,true,true}
            },
            new Position(0, 3)
            )
        {
        }


    }

}
