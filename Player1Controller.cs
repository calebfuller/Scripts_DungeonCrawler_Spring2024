using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Controller : MonoBehaviour
{
    private Player thePlayer;
   public TextMeshPro tm;
   public GameObject destinationGO;
   public float speed = 5f;
   
   void Start()
   {
	   this.thePlayer = new Player("Caleb");
	   tm.text = this.thePlayer.getName() + " -> " + this.thePlayer.getHP();
	   this.gameObject.transform.position = this.destinationGO.transform.position;

   }

   private void FixedUpdate()
   {
	   if (Vector3.Distance(this.gameObject.transform.position != this.destinationGO.transform.position) > 1.0f)
	   {
	   this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, 
												this.destinationGO.transform.position, 
												speed * Time.deltaTime);
       }
	   this.thePlayer.display();
	   /*
	   if(MySingleton.player1Turn == true)
	   {
	   print("**** PLAYER 1: " + MySingleton.count + "****")
	   MySingleton.count++;
	   MySingleton.player1Turn = false;
	   }
	   */
   }
}
