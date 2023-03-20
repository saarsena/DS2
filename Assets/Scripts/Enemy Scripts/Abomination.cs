using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Abomination : Enemy
{
    float randomFloat;
    private float health;
    private float mana = 0f;
    private float armorValue = 17f;
    private float attackValue = 9f;
    private int numberOfAttacks = 3;
    private int str = 21;
    private int dex = 9;
    private int con = 15;
    private int intel = 18;
    private int wis = 15;
    public int charis = 18;
    public bool isEnemy = true;

    public override float Health
    {
        get
        {
            return health = (18 * randomFloat) + 36;
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
    private void Start()
    {
        
        randomFloat = Random.Range(0f, 10f);
    }
}
