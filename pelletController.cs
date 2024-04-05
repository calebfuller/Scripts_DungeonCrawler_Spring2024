using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelletController : MonoBehaviour
{
    public Vector3 startingPosition;
    public string direction;
    private void CollectPellet;
    private void ReturnToBeginning;
    
    
    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			StartCoroutine(StartFightScene(other.gameObject));
		}
	}
    
    IEnumerator StartFightScene(GameObject player)
    {
        PlayertoScene = player.GetComponent<PlayerController>();
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FightScene", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
		{
			yield return null;
		}
        
        fightController fightController = GameObject.Find("FightController").GetComponent<fightController>();
        yield return StartCoroutine(fightController.StartFight(PlayertoScene));

        if(fightController.theMonster.getHP() <= 0)
        {
			CollectPellet(player);
		}
		else
		{
			ReturnToBeginning(player);
		}
    }

    private void CollectPellet(GameObject player)
    {
        Destroy(gameObject);
    }

    private void ReturnToBeginning(GameObject player)
	{
		AsyncOperation ansycLoad = SceneManager.LoadSceneAsync("MainScene");
	}

    void Update()
    {
        
    }
}