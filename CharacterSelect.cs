using System;

class CharacterSelect
{
    public Character Player { get; set; }
    public Character Computer { get; set; }
    public void CharacterCreation()
    {


        Console.WriteLine("What character do you want to play as? 1 - Archer, 2 - Warrior, 3 - Mage");
        var userChoice = Console.ReadLine();

        Console.WriteLine("Enter your hero's name: ");
        var userName = Console.ReadLine();

        if (userChoice == "1")
        {
            Player = new Archer(userName);
        }
        else if (userChoice == "2")
        {
            Player = new Warrior(userName);
        }
        else
        {
            Player = new Mage(userName);
        }

        //maybe roll a dice to determine computers class
        var computerPick = new Dice(3);
        var computerClass = computerPick.GetRoll();
        if (computerClass == 1)
        {
            Computer = new Archer("Legolas");
        }
        else if (computerClass == 2)
        {
            Computer = new Warrior("Gimli");
        }
        else
        {
            Computer = new Mage("Gandalf");
        }
    }
}