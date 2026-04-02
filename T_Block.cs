using System;

namespace GridGameProject.GameLogic
{
    public class T_Block: Block
    {
        public T_Block() : base(
            new bool[,]
            {
                {false,true,false},
                {true,true,true},
                {false,false,false}
            },
            new Position(0, 3)
            )
        {
        }
               
        
    }

}
