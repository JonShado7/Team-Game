using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats/AI Stats")]
public class AI_Stats : ScriptableObject
{
    [Header("=====DEFAULT STATS=====")]
    public float moveSpeed;
    public float sphereLookRadius;
    public float sightRange;
    public float searchDuration;

}
