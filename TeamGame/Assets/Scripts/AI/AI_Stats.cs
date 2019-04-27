using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats/AI Stats")]
public class AI_Stats : ScriptableObject
{
    public float currentHealth;
    public float maxHealth;
    public float attackSpeed;
    public float attackPower;
    public float moveSpeed;
    public int damage;
    public float sphereLookRadius;
    public float sightRange;
    public float searchDuration;
    public float searchTurnSpeed;

}
