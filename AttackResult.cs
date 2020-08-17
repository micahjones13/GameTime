using System;

class AttackResult
{

    public StatusEffect? StatusEffect { get; set; } //nullabe

    public int AttackRoll { get; set; }
    public int AttackDmg { get; set; }

    public bool DidCrit { get; set; }

    public DamageType DamageType { get; set; } //magic, range, melee   magic > melee, melee > range, range > magic


}