using System;

class Archer : Character
{

    private Dice AttackDice = new Dice(6); //capitalize fields
    private Dice HealDice = new Dice(4);

    private static int StartingHealth = 50;  //now exists for all mages


    public Archer(string name) : base(StartingHealth, name)
    {

    }


    public override AttackResult Attack()
    {
        var attackresult = new AttackResult();
        if (StatusState == StatusEffect.Paralyzed)
        {
            Console.WriteLine($"{GetName()} is paralyzed and cannot attack!");
            return attackresult;
        }
        var dmg = AttackDice.GetRoll();
        attackresult.AttackRoll = dmg;
        attackresult.DamageType = DamageType.Range;

        if (dmg == 6)
        {
            attackresult.DidCrit = true;
            attackresult.AttackDmg = (dmg * 2);
            attackresult.StatusEffect = StatusEffect.Poisoned;
        }
        return attackresult;
    }
    public override int Heal()
    {
        var healAmount = HealDice.GetRoll();
        Health = Health + healAmount;
        if (Health > StartingHealth)
        {
            Health = StartingHealth;
        }
        return healAmount;
    }
    public override HitResult Hit(AttackResult attackresult)
    {
        var hitresult = new HitResult();
        var damage = attackresult.AttackRoll;
        HandleStatus(attackresult); // pass that status effect to be set on character
        hitresult.ExpectedDamage = damage;

        //* If melee, take full dmg. Cannot dodge.
        if (attackresult.DamageType == DamageType.Melee)
        {
            //* If frozen, take double dmg
            if (StatusState == StatusEffect.Frozen)
            {
                Health = Health - (damage * 2);
            }
            else
            {
                Health = Health - damage;
                hitresult.DamageTaken = damage;
            }
        }
        //* Cannot dodge damage >= 3
        else if (damage >= 3)
        {
            if (StatusState == StatusEffect.Frozen)
            {
                Health = Health - (damage * 2);
                hitresult.DamageTaken = damage * 2;
            }
            else
            {
                Health = Health - damage;
                hitresult.DamageTaken = damage;
            }
        }
        //* Possible dodge
        else
        {
            if (StatusState == StatusEffect.Frozen)
            {
                Health = Health - (damage * 2);
                hitresult.DamageTaken = damage * 2;
            }
            else
            {
                hitresult.DidDodge = true;
            }
        }
        return hitresult;
    }


}



