using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string name;
    private List<string> theOpenDoors = new List<string>();

    public Room(string name)
    {
        this.name = name;
    }

    public void setOpenDoor(string direction)
    {
        this.theOpenDoors.Add(direction);
    }

    public bool isOpenDoor(string direction)
    {
        for(int i = 0; i < this.howManyOpenDoors; i++)
        {
            if(direction.Equals(this.theOpenDoors[i]))
            {
                return true;
            }
        }
        return false;
    }

    public int getIndex(Room room)
    {
        return MySingleton.getRoomIndex(room);
    }

}
