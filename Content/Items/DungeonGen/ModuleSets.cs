using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeondelvers.Content.Items.DungeonGen
{
    public class ModuleSets
    {
        public enum ModuleTypes
        {
            RightDeadEnd,
            LeftDeadEnd,
            UpDeadEnd,
            DownDeadEnd,

        }
        public struct Module0
        {
            public byte ID = 0;
            public byte LeftSocket , RightSocket , TopSocket , BottomSocket ;

            public Module0()
            {
                ID = 0;
                LeftSocket = 0;
                RightSocket = 0;
                TopSocket = 0;
                BottomSocket = 0;
            }
        }
    }
}
