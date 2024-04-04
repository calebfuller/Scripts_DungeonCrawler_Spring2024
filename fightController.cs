using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP, monster_hp_TMP;
    public TextMeshPro damageDone;
    private GameObject currentAttacker;
    private Animator theCurrentAnimator;
    private Monster theMonster;
    private bool shouldAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Pink Ghost");
        this.hero_hp_TMP.text = "Current HP: " + MySingleton.thePlayer.getHP() + " AC: " + MySingleton.thePlayer.getAC();
        this.monster_hp_TMP.text = "Current HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();

        int num = Random.Range(0, 2); //coin flip, will produce 0 and 1 (since 2 is not included)
        if(num == 0)
        {
            this.currentAttacker = hero_GO;
        }
        else
        {
            this.currentAttacker = monster_GO;
        }

        StartCoroutine(fight());
    }

    private void tryAttack(Inhabitant attacker, Inhabitant defender)
    {
        //have attacker try to attack the defender
        int attackRoll = Random.Range(0, 20)+1;
        if(attackRoll >= defender.getAC())
        {
            //attacker will hit the defender, lets see how hard!!!!
            int damageRoll = Random.Range(0, 4) + 2; //damage between 2 and 5
            defender.takeDamage(damageRoll);
            print("Attacker Hits for " + damageRoll + " damage!!!!");
            theCurrentAnimator.SetTrigger("hit");
        }
        else
        {
            print("Swing and a miss!!!!");
        }
    }

    IEnumerator fight()
    {
        yield return new WaitForSeconds(2);
        if (this.shouldAttack)
        {
            this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
            this.theCurrentAnimator.SetTrigger("attack");
            if (this.currentAttacker == this.hero_GO)
            {
                this.currentAttacker = this.monster_GO;
                this.tryAttack(MySingleton.thePlayer, this.theMonster);
                this.monster_hp_TMP.text = "Current HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();

                //now the defender may have fewer hp...check if their are dead?
                if (this.theMonster.getHP() <= 0)
                {
                    print(MySingleton.thePlayer + " has defeated " + this.theMonster.getname + "!!!!");
                    theCurrentAnimator.SetTrigger("disappear");
                    this.shouldAttack = false;
                }
                else
                {
                    StartCoroutine(fight());
                }
                
            }
            else
            {
                this.currentAttacker = this.hero_GO;
                this.tryAttack(this.theMonster, MySingleton.thePlayer);
                this.hero_hp_TMP.text = "Current HP: " + MySingleton.thePlayer.getHP() + " AC: " + MySingleton.thePlayer.getAC();

                //now the defender may have fewer hp...check if their are dead?
                if (MySingleton.thePlayer.getHP() <= 0)
                {
                    print("Monster has defeated " + MySingleton.thePlayer + "!!!!");
                    theCurrentAnimator.SetTrigger("disappear");
                    this.shouldAttack = false;
                }
                else
                {
                    StartCoroutine(fight());
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }
}
