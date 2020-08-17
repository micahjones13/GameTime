using System;

abstract class Character
{
    protected int Health { get; set; } //protected = only character and a class that inehirts from it can change health
    private string Name;
    protected StatusEffect? StatusState { get; set; } //? means this is nullable. it may or may not have one

    public Character(int startingHealth, string name) //, string statuseffect
    {
        Health = startingHealth;
        Name = name;

    }

    public bool IsDead()
    {
        return Health <= 0; //return a bool
        //if true, palyer is dead
    }
    public int GetHealth()
    {
        return Health;
    }
    public string GetName()
    {
        return Name;
    }

    public abstract AttackResult Attack(); //maybe returns an attack result, posion ect
    public abstract int Heal(); //end of round, maybe heals their posion 

    public abstract HitResult Hit(AttackResult attackresult); //how characters recieve damage. Warriors could recieve less, ect.

    protected void HandleStatus(AttackResult attackresult)
    {
        if (attackresult.StatusEffect.HasValue) //HasValue return a bool according to null or not
        {
            StatusState = attackresult.StatusEffect; //set the character statuseffect to the active status effect
            Console.WriteLine($"{Name} has been {StatusState}!");
        }
    }


    //EndOfRound, deal with Poison effects, end effects if the duration has passed.
    //Frozen - Frozen for 2 Turns
    //Poisoned - Poisoned for 2 Turns
    //Paralyzed - Lose 1 turn

    /*
    End of round could keep track of the number of turns since a status has been applied, and then revert status back to null after it passes.

    */
    protected void EndOfRound()
    {
        var statusTime = 0; //This will store the amount of EndOfRound calls have passed after an effect is applied. Might need to add to character fields?
        //*If we want the effects to last a certain amount of turns, we will need to consider what a turn is, relative to the call of endofround
        //* I think that we will need to set the condition for resetting statuseffect to + 1 of what we would think the turns would be, because it will go to 1 immediately
        if (StatusState.HasValue)
        {

            switch (StatusState)
            {
                case StatusEffect.Frozen:
                    statusTime++;
                    if (statusTime == 3)
                    {
                        StatusState = null;
                    }
                    break;
                case StatusEffect.Paralyzed:
                    statusTime++;
                    if (statusTime == 2)
                    {
                        StatusState = null;
                    }
                    break;
                case StatusEffect.Poisoned:
                    statusTime++;
                    if (statusTime == 3)
                    {
                        StatusState = null;
                    }
                    break;
                default:
                    return;
            }
        }

        Console.WriteLine($"{Name} has {Health} reamaining!");

    }

}


/*
Capitalize fields and function names
abstract = not finished, and must be defined by the class that inherits from it
private = cannot be changed by any class other than the defining class 
protected = only defined class and any class that inheritis from it can modify field 
readonly = cannot be changed
void = no return value


frozen could mean take more damage when hit while frozen
paralyzed can't move during turn
poisoned take additional posion damage until no longer poisoned\
some of these may need to be put into attack or hit 


*/