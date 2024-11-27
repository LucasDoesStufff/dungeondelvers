using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeondelvers.Content.Items.DungeonGen
{
    internal class DungeonGenerator
    {
        /*
         * randomly place from x amount of starting rooms to a random location inside dungeon boundaries
         * search for left, right, down, up and place corresponding corridors/rooms randomly
         * place down special rooms
         * count the amount of rooms and corridors and generate dead ends after enough of the rooms are placed
         * clear the directional blocks for generation
         *
         */


        /*
         * make a set amount of forced rooms depending on dungoen size which can differ from stage to stage and make the generator generate the rooms before creating dead ends
         * increment the chance of dead ends if the corridor gets too far
         * find a way to delete/connect the corridors that lead to nowhere or add a room at the end
         *
         */
    }
}
