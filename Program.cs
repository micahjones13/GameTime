using System;

namespace GameTime
{
    class Program
    {
        static void Main(string[] args)
        {

            var characters = new CharacterSelect();
            characters.CharacterCreation();
            var battle = new BattleHandler();
            battle.Battle(characters.Player, characters.Computer);

        }

    }
}

