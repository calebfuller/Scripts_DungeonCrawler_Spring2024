using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP, monster_hp_TMP;

    // Start is called before the first frame update
    void Start()
    {
        this.hero_hp_TMP.text = "Boo!!!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
