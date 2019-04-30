using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats/AI Stats/ Fighter Stats")]
public class FighterStats : AI_Stats
{
    [Header("=====Movement & Sight=====")]
    public bool isSpawnable;

    [Header("=====Attributes=====")]
    public float currentHealth;
    public float maxHealth;
    public float currentStamina;
    public float maxStamina;
    public float attackSpeed;
    public float attackPower;
    public float attackRange;
    public int attackDamage;

    [Header("=====Mage Type=====")]
    public FighterType fighterType = FighterType.DEFAULT;
    public ConfidenceLevel confidence = ConfidenceLevel.DEFAULT;
}
