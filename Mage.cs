using System;

class Mage : Character
{
    private Dice AttackDice = new Dice(8);
    private Dice HealDice = new Dice(6);

    private static int StartingHealth = 40;  //now exists for all mages

    public Mage(string name) : base(StartingHealth, name)
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
        attackresult.DamageType = DamageType.Magic;

        if (dmg == 8)
        {
            attackresult.DidCrit = true;
            attackresult.AttackDmg = (dmg * 2); //changed from AttackRoll to AttackDmg, to prevent the writline from displaying the roll as double
            attackresult.StatusEffect = StatusEffect.Frozen;
        }
        return attackresult;
    }
    public override int Heal()
    {
        var healAmount = HealDice.GetRoll();
        Health = Health + (healAmount + 2);
        //* Refactor on character, don't hardcode 40
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
        hitresult.ExpectedDamage = attackresult.AttackRoll;


        //* If hit by range, take full damage.
        if (attackresult.DamageType == DamageType.Range)
        {
            //* If frozen, take double
            if (StatusState == StatusEffect.Frozen)
            {
                Health = Health - (damage * 2); //maybe chagne this to be less damage later
                hitresult.DamageTaken = damage * 2;
            }
            else
            {
                Health = Health - damage;
                hitresult.DamageTaken = damage;
            }
        }
        else
        {
            //* If frozen, take double
            if (StatusState == StatusEffect.Frozen)
            {
                Health = Health - (damage * 2);
                hitresult.DamageTaken = damage * 2;
            }

            else
            {
                var dmgAfterBlock = damage - 1;
                Health = Health - dmgAfterBlock;
                hitresult.DamageTaken = dmgAfterBlock;
                hitresult.DidBlock = true;
            }
        }



        return hitresult;
    }
}


// enums - enumeration
// allows you to compile specific types 