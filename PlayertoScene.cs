using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayertoScene : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Exit"))
            {
                LoadNextRoom();
            }
    }

    private void LoadNextRoom()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
