using System;

namespace GridGameProject.GameLogic
{
    public class I_Block : Block
    {
        public I_Block() : base(
            new bool[,]
            {
                {false,true,false},
                {false,true,false},
                {false,true,false}
            },
            new Position(0, 3)
            )
        {
        }


    }

}
