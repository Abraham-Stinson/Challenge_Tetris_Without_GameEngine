using System;

namespace GridGameProject.GameLogic
{
    public class Z_Block : Block
    {
        public Z_Block() : base(
            new bool[,]
            {
                {false,false,false},
                {true,true,false},
                {false,true,true}
            },
            new Position(0, 3)
            )
        {
        }


    }

}
