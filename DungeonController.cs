using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject[] closedDoors;

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
        if(MySingleton.theCurrentRoom == null)
        {
            MySingleton.theCurrentRoom = new Room("a room");
            MySingleton.addRoom(MySingleton.theCurrentRoom);
        }
        else
        {
            MySingleton.theCurrentRoom = MySingleton.previousRoom;
        }

        int openDoorIndex = Random.Range(0, 4);
        this.closedDoors[openDoorIndex].SetActive(false);
        MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(openDoorIndex));

        for(int i = 0; i < 4; i++)
        {
            if(openDoorIndex != i)
            {
                int coinFlip = Random.Range(0, 2);
                if(coinFlip == 1)
                {
                    this.closedDoors[i].SetActive(false);
                    MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(i));

                }
            }
        }
        if(MySingleton.previousRoom != null)
        {
            int previousIndex = MySingleton.previousRoom.getIndex(MySingleton.theCurrentRoom);
            int oppositeDoorIndex = (previousIndex + 2) % 4;
            MySingleton.theCurrentRoom.setOpenDoor(mapIndexToStringForExit(oppositeDoorIndex));
        }
       
    }

    void Update()
    {
        
    }
}