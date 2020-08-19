using System;
class BattleHandler
{
    // public List<Character> Opponents {get; set;}

    public void Battle(Character player, Character computer)
    {
        do
        {
            // ask player to choose attack or heal
            Console.WriteLine("Will you 1 - attack or 2 - heal?");
            var userChoice = Console.ReadLine();
            //If player decides to attack
            if (userChoice == "1")
            {
                var playerTurn = player.Attack();
                Console.WriteLine($"{player.GetName()} attacks! They rolled a {playerTurn.AttackRoll}!");
                var computerTakesHit = computer.Hit(playerTurn);
                Console.WriteLine($"{computer.GetName()} took {computerTakesHit.DamageTaken}!");
                if (computerTakesHit.DidBlock || computerTakesHit.DidDodge)
                {
                    Console.WriteLine($"{computer.GetName()} dodged/blocked the attack!");
                }
            }
            //player wants to heal
            else
            {
                Console.WriteLine($"{player.GetName()} drinks a health potion! They restore {player.Heal()} HP!");
            }
            var randDice = new Dice(2);
            var compChoice = randDice.GetRoll();
            if (compChoice == 1)
            {
                //comp attacks
                var computerTurn = computer.Attack();
                Console.WriteLine($"{computer.GetName()} attacks! They rolled a {computerTurn.AttackRoll}");
                var playerTakesHit = player.Hit(computerTurn);
                Console.WriteLine($"{player.GetName()} took {playerTakesHit.DamageTaken}!");
                if (playerTakesHit.DidBlock || playerTakesHit.DidDodge)
                {
                    Console.WriteLine($"{player.GetName()} dodged/blocked the attack!");
                }
            }
            else
            {
                Console.WriteLine($"{computer.GetName()} drinks a health potion! They restore {computer.Heal()} HP!");
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


/*
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

*/