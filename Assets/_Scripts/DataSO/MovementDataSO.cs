using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Agent/MovementData")]
public class MovementDataSO : ScriptableObject
{
    [Range(1f, 10f)]
    public float maxSpeed = 5;

    [Range(0.1f, 100f)]
    public float acceleration = 50f, deceleration = 50f;
}
