using System;

class Warrior : Character
{

    private Dice AttackDice = new Dice(6); //capitalize fields
    private Dice HealDice = new Dice(4);

    public Warrior(string name) : base(60, name)
    {

    }


    public override AttackResult Attack()
    {
        var attackresult = new AttackResult();
        var dmg = AttackDice.GetRoll();
        attackresult.AttackRoll = dmg;
        attackresult.DamageType = DamageType.Melee;
        if (dmg == 6)
        {
            attackresult.DidCrit = true;
            attackresult.AttackDmg = (dmg * 2);
            attackresult.StatusEffect = StatusEffect.Paralyzed;

        }

        return attackresult;

    }
    public override int Heal()
    {
        var healAmount = HealDice.GetRoll();
        Health = Health + healAmount;
        return healAmount;
    }
    public override HitResult Hit(AttackResult attackresult)
    {
        var hitresult = new HitResult();
        var damage = attackresult.AttackRoll;
        HandleStatus(attackresult); // pass that status effect to be set on character
        hitresult.ExpectedDamage = damage;

        //* If magic, cannot block
        if (attackresult.DamageType == DamageType.Magic)
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
        //* Possible Block
        else if (damage >= 2)
        {
            //* Can't block if frozen.
            if (StatusState == StatusEffect.Frozen)
            {
                Health = Health - (damage * 2);
                hitresult.DamageTaken = damage * 2;
            }
            //* Block
            else
            {
                var blockAmount = damage - 2;
                Health = Health - (blockAmount);
                hitresult.DamageTaken = blockAmount;
                hitresult.DidBlock = true;
            }

        }


        return hitresult;


    }


}



/*
override = when a function is defined in a class as abstract, overide is used in inheriting class to define function
base = call parent constructor

*/