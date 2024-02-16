using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayertoScene : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //not our first scene
        if(!MySingleton.currentDirection.Equals("?"))
        {
            if(MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("door"))
        {
            MySingleton.currentDirection = "north";
            EditorSceneManager.LoadScene("DungeonRoom");
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);

    }
}