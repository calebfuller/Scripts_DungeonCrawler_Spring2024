using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player2Controller : MonoBehaviour
{
    private Player thePlayer;
    public TextMeshPro tm;
    void Start()
    {
        this.thePlayer = new Player("Dave");
        tm.text = this.thePlayer.getName() + " -> " + this.thePlayer.getHP();

    }

    private void FixedUpdate()
    {
        this.thePlayer.display();
    }
}