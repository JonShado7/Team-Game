using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerData")]
public class PlayerStats : ScriptableObject
{
    public float currentHealth;
    public float maxHealth;
    public int playerLevel;
    

}
