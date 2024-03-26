using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inhabitant
{
    protected string name;
    protected Room currentRoom;

    public Inhabitant(string name)
    {
        this.name = name;
        this.currentRoom = null;
        Random r = new Random();
        this.hp = r.Next(10,15);
        this.damage = r.Next(1,5);
    }

    public string getData()
    {
        string s = this.name;
        s = s + " - " + this.hp;
        return s;
    }

    public int getDamage()
    {
        return this.damage;
    }

    public void takeDamage(int damage)
    {
        this.hp = this.hp - damage;
    }
}