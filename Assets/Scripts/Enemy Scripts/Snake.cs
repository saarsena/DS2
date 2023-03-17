using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Enemy
{
    private float health = 300f;
    private float mana = 500f;
    private float armorValue = 0;
    private float attackValue = 5f;
    private int numberOfAttacks = 1;
    private int str = 10;
    private int dex = 10;
    private int con = 10;
    private int intel = 10;
    private int wis = 10;
    public int charis = 10;
    public bool isEnemy = true;

    public override float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public override float Mana
    {
        get
        {
            return mana;
        }
        set
        {
            mana = value;
        }
    }
    public override float ArmorValue
    {
        get
        {
            return armorValue;
        }
        set
        {
            armorValue = value;
        }
    }
    public override float AttackValue
    {
        get
        {
            return attackValue;
        }
        set
        {
            attackValue = value;
        }
    }

    public override int NumberOfAttacks
    {
        get
        {
            return numberOfAttacks;
        }
        set
        {
            numberOfAttacks = value;
        }
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
}
