using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject northDoor, southDoor, eastDoor, westDoor;

    private string mapIndexToStringForExit(int index)
    {
        if(index == 0)
        {
            return "north";
        }
        else if (index == 1)
        {
            return "south";
        }
        else if (index == 2)
        {
            return "east";
        }
        else if (index == 3)
        {
            return "west";
        }
        else
        {
            return "?";
        }
    }
    void Start()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if(theCurrentRoom.hasExit("north"))
        {
            this.northDoor.SetActive(false);
        }

        if (theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
        }

        if (theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
        }

        if (theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
        }
       
    }

    void Update()
    {
        
    }
}