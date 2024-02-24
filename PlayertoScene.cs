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
    public GameObject middleOfTheRoom;
    private float speed = 5.0f;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;

    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);

    }

    private void turnOnExits(int numberOfExits)
    {
        this.northExit.gameObject.SetActive(true);
        this.southExit.gameObject.SetActive(true);
        this.eastExit.gameObject.SetActive(true);
        this.westExit.gameObject.SetActive(true);
    }

    void Start()
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

        this.turnOffExits();

        this.middleOfTheRoom.SetActive(false);
        
        int numberOfExits = Random.Range(1, 5);
        this.turnOnExits(numberOfExits);

        if (!MySingleton.currentDirection.Equals("?"))
        {
            this.amMoving = true;

            this.middleOfTheRoom.SetActive(true);
            this.amAtMiddleOfRoom = false;

            if (MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.gameObject.transform.LookAt(this.northExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.gameObject.transform.LookAt(this.southExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.gameObject.transform.LookAt(this.westExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.gameObject.transform.LookAt(this.eastExit.transform.position);
            }
        }
        else
        {
            this.amMoving = false;
            this.amAtMiddleOfRoom = true;
            this.middleOfTheRoom.SetActive(false);
            this.gameObject.transform.position = this.middleOfTheRoom.transform.position;
        }
    }

    /*
    IEnumerator turnOnMiddle()
    {
        yield return new WaitForSeconds(1);
        this.middleOfTheRoom.SetActive(true);
        print("turned on");

    }
    */

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if(other.CompareTag("door"))
        {
            print("Loading scene");

            EditorSceneManager.LoadScene("DungeonRoom");
        }
        else if(other.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            this.middleOfTheRoom.SetActive(false);
            this.turnOnExits();

            print("middle");
            this.amAtMiddleOfRoom = true;
            this.amMoving = false;
            MySingleton.currentDirection = "middle";
        }
        else
        {
            print("spomethilskdfjskldjfsdjkl");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("north"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("south"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("west"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("east"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);

        }

        if (MySingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.speed * Time.deltaTime);
        }
    }
}