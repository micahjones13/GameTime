using System;

namespace GameTime
{
    class Program
    {
        static void Main(string[] args)
        {
            //eventually want the player to choose class and name

            Console.WriteLine("What character do you want to play as? 1 - Archer, 2 - Warrior, 3 - Mage");
            var userChoice = Console.ReadLine();

            Console.WriteLine("Enter your hero's name: ");
            var userName = Console.ReadLine();
            Character player;
            if (userChoice == "1")
            {
                player = new Archer(userName);
            }
            else if (userChoice == "2")
            {
                player = new Warrior(userName);
            }
            else
            {
                player = new Mage(userName);
            }

            //maybe roll a dice to determine computers class
            var computerPick = new Dice(3);
            var computerClass = computerPick.GetRoll();
            Character computer;
            if (computerClass == 1)
            {
                computer = new Archer("Legolas");
            }
            else if (computerClass == 2)
            {
                computer = new Warrior("Gimli");
            }
            else
            {
                computer = new Mage("Gandalf");
            }




            do
            {


                var playerTurn = player.Attack();
                var computerTurn = computer.Attack();

                Console.WriteLine($"{player.GetName()} rolled a {playerTurn.AttackRoll}");
                Console.WriteLine($"{computer.GetName()} rolled a {computerTurn.AttackRoll}");

                var computerTakesHit = computer.Hit(playerTurn);
                var playerTakesHit = player.Hit(computerTurn);

                Console.WriteLine($"{computer.GetName()} took {computerTakesHit.DamageTaken}!");
                if (computerTakesHit.DidBlock || computerTakesHit.DidDodge)
                {
                    Console.WriteLine($"{computer.GetName()} dodged/blocked the attack!");
                }

                Console.WriteLine($"{player.GetName()} took {playerTakesHit.DamageTaken}!");
                if (playerTakesHit.DidBlock || playerTakesHit.DidDodge)
                {
                    Console.WriteLine($"{player.GetName()} dodged/blocked the attack!");
                }
                player.EndOfRound();
                computer.EndOfRound();







            }
            while (!player.IsDead() && !computer.IsDead());
            if (player.IsDead())
            {
                Console.WriteLine($"{player.GetName()} is dead! Computer wins!");
            }
            else
            {
                Console.WriteLine($"{computer.GetName()} is dead! Player wins!");
            }

        }

    }
}

// create an attack result, which would be taken in by Hit()

// Refactor some code that is being re-used. 
// If it's on all sub-classes, it could be on character. 
// Get it working, then refactor.

/*
Have player choose attack/heal, maybe buy weapons


*/