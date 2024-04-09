using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int pelletsCollected = 0;
    public int attackBonus = 3;
    public TextMeshProUGUI pelletText;

    void Update()
	{
		pelletText.text = "Pellets: " + pelletsCollected;
	}

    public void CollectPellet()
    {
        pelletsCollected++;
    }

    public void SpendPellets(int amount)
    {
        if (pelletsCollected >= amount)
        {
			pelletsCollected -= amount;
            ApplyAttackBonus();
		}
        else
        {
			Debug.Log("Not enough pellets");
		}
    }

    void ApplyAttackBonus()
	{
		int newAttack = MySingleton.thePlayer.hp + attackBonus;
		Debug.Log("Attack bonus is now " + attackBonus);
	}
}