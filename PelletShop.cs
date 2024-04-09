using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletShop : MonoBehaviour
{
    public int attackBonusCost = 5;
    public PlayerController PlayerController;
	
	public void BuyAttackBonus()
	{
		MySingleton.thePlayer.SpendPellets(5);
	}
}
