using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.Direction = Vector2.zero;
        aiMovementData.PointOfInterest = enemyBrain.Target.transform.position;
        enemyBrain.Move(Vector2.zero, aiMovementData.PointOfInterest);
        aiActionData.Attack = true;
        enemyBrain.Attack();
    }
}