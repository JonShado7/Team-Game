using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mage Stats", menuName = "Stats/AI Stats/ Mage Stats")]
public class MageStats : AI_Stats
{
    [Header("=====Movement & Sight=====")]
    public bool isSpawnable;

    [Header("=====Attributes=====")]
    public float castSpeed;
    public float magicPower;
    public float castRange;
    public int magicDamage;

    [Header("=====Mage Type=====")]
    public MageType type = MageType.basic;
}
