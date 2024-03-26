using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatch
{
    private Inhabitant guy1;
    private Inhabitant guy2;
    private GameObject guy1FIGHT;
    private GameObject guy2FIGHT;
    private Rigidbody currRigidBodyOfAttacker;
    private float attackMoveDistance = 2.5f;
    private Vector3 attackerOriginalPosition;
    private Inhabitant currentAttacker;
    private Inhabitant currentAttackerFIGHT;

    public DeathMatch(Inhabitant guy1, Inhabitant guy2, GameObject guy1FIGHT, GameObject guy2FIGHT)
    {
        this.guy1 = guy1;
        this.guy2 = guy2;
        this.guy1FIGHT = guy1FIGHT;
        this.guy2FIGHT = guy2FIGHT;
        this.currentAttacker = this.guy1;
        this.currentAttackerFIGHT = this.guy1FIGHT;
    }

    IEnumerator MoveObjectRoutine();
    {
        Vector3 originalPosition = this.attackerOriginalPosition;
        Vector3 targetPosition = originalPosition + this.currentAttackerFIGHT.transform.right * attackMoveDistance;

        this.currRigidBodyOfAttacker.MovePosition(targetPosition);
        yield return new WaitForSeconds(1.5f);
        this.currRigidBodyOfAttacker.MovePosition(originalPosition);
      
    }

    public void fight()
    {
        this.attackerOriginalPosition = this.currentAttackerFIGHT.transform.position;
        this.currRigidBodyOfAttacker = this.currentAttackerFIGHT.GetComponent<Rigidbody>();
        this.attackMoveDistance *= -1;

        if (this.currentAttackerFIGHT == this.guy1FIGHT)
        {
            this.currentAttackerFIGHT = this.guy2FIGHT;
        }
        else
        {
            this.currentAttackerFIGHT = this.guy1FIGHT;
        }
    }
}
