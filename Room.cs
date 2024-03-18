using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string name;
    private List<GameObject> powerPellets = new List<GameObject>();
    private Exit[] theExits = new Exit[4];
    private int howManyExits = 0;
    private Player currentPlayer;

    public Room(string name)
    {
        this.name = name;
        this.currentPlayer = null;
    }

    public void addPlayer(Player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this);
    }

    public void removePlayer()
    {
        this.currentPlayer = null;
    }

    public bool hasExit(string direction)
    {
        for(int i = 0; i < this.howManyExits; i++)
        {
            if(this.theExits[i].getDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }

    public void addExit(string direction, Room destinationRoom)
    {
        if(this.howManyExits < this.theExits.Length)
        {
            Exit e = new Exit(direction, destinationRoom);
            this.theExits[this.howManyExits] = e;
            this.howManyExits++;
        }
    }

    public void placePowerPellets()
    {
        foreach(Exit exit in theExits)
        {
            if(exit != null)
            {
                powerPellets.Add(pellet);
            }
        }
    }

    public void removeCollectedPellets()
    {
        foreach(GameObject pellet in powerPellets)
        {
            powerPellets.Clear();
        }
    }
}
