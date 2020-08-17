using System;

class Dice
{
    private readonly int Sides;
    private readonly Random Randomizer = new Random();
    //dice have different amount of sides, d20 ect 
    public Dice(int sides)
    {
        Sides = sides;
    }
    public int GetRoll()
    {
        return Randomizer.Next(1, Sides + 1);
    }
}