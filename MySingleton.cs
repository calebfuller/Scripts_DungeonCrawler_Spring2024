using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton
{
    public static string currentDirection = "?";
    private static Room[] theRooms = new Room[100];
    private static int numRooms = 0;
    public static Room theCurrentRoom = null;
    public static Room previousRoom = null;

    public static void addRoom(Room r)
    {
        theRooms.Add(r);
        theCurrentRoom = r;
    }   

    public static Room getRoom(int index)
    {
        return theRooms[index];
    }
}