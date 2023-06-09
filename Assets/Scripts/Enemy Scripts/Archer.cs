using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy
{
    private float health = 150f;
    private float mana = 0;
    private float armorValue = 0;
    private float attackValue = 5f;
    private int numberOfAttacks = 2;
    private int str = 12;
    private int dex = 16;
    private int con = 12;
    private int intel = 10;
    private int wis = 10;
    private int charis = 10;
    public bool isEnemy = true;
    Bonuses abilityBonus = new Bonuses();
    private int tempAbilityBonus;

    public override float Health
    {
        get { return health; }
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
    }
}
