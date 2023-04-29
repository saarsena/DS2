using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Djinn : Enemy
{
    private int randomDie;
    private float health;
    private float mana;
    private float armorValue = 17;
    private float attackValue;
    private int numberOfAttacks = 3;
    private int str = 21;
    private int dex = 15;
    private int con = 22;
    private int intel = 15;
    private int wis = 16;
    public int charis = 20;
    public bool isEnemy = true;
    Bonuses abilityBonus = new Bonuses();
    private int tempAbilityBonus;

    public override float Health
    {
        get { return health = 14 * randomDie + 84; }
        set { health = value; }
    }
    public override float Mana
    {
        get { return mana; }
        set { mana = value; }
    }
    public override float ArmorValue
    {
        get { return armorValue; }
        set { armorValue = value; }
    }
    public override float AttackValue
    {
        get { return attackValue; }
        set { attackValue = value; }
    }
    public override int NumberOfAttacks
    {
        get { return numberOfAttacks; }
        set { numberOfAttacks = value; }
    }
    public override int Str
    {
        get { return str; }
        set { str = value; }
    }
    public override int Dex
    {
        get { return dex; }
        set { dex = value; }
    }
    public override int Con
    {
        get { return con; }
        set { con = value; }
    }
    public override int Int
    {
        get { return intel; }
        set { intel = value; }
    }
    public override int Wis
    {
        get { return wis; }
        set { wis = value; }
    }
    public override int Cha
    {
        get { return charis; }
        set { charis = value; }
    }
    public override bool IsEnemy
    {
        get { return isEnemy; }
        set { isEnemy = value; }
    }
    public override int AbilityModifier
    {
        get { return tempAbilityBonus; }
        set { tempAbilityBonus = value; }
    }
    private void Start()
    {
        tempAbilityBonus = abilityBonus.GetAbilityBonus(Str);
        randomDie = Random.Range(1, 10);
    }
}
