using System;

namespace GridGameProject.GameLogic
{
    public class O_Block : Block
    {
        public O_Block() : base(
            new bool[,]
            {
                {true,true,true},
                {true,true,true},
                {true,true,true}
            },
            new Position(0, 3)
            )
        {
        }


    }

}
