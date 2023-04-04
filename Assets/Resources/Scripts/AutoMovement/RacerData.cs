using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Racer", menuName = "RaceGame/Racer", order = 0)]
public class RacerData : ScriptableObject
{
    [Range(0f, 1f)]
    public float skill;
    [Range(0f, 1f)]
    public float aggression;
    [Range(0f, 1f)]
    public float control;
    [Range(0f, 1f)]
    public float mistakes;
}
