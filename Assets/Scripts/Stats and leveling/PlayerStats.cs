using UnityEngine;
using System;
using System.Collections.Generic;
// makes the player stats visable in the inspector  
[Serializable]
public class PlayerStats
{
    //player's name which can be edited in the inspector
    [Header("Character Name")]
    public string name;
    // displays the player's health and stamina
    [Header("Character Attributes")]
    public Attribute health;
    public Attribute stamina;
    //displays the player's current level and experience 
    [Header("Character Level")]
    public int level;
    public Attribute experience;
    //lists off the player's current stats with their values
    [Header("Character Stats")]
    public List<Stat> stats = new List<Stat>
    {
    new Stat { name = "Strength", statValue = 12, value = 0 },
    new Stat { name = "Dexterity", statValue = 14, value = 0 },
    new Stat { name = "Constitution", statValue = 13, value = 0 },
    new Stat { name = "Intelligence", statValue = 10, value = 0 },
    new Stat { name = "Wisdom", statValue = 11, value = 0 },
    new Stat { name = "Charisma", statValue = 8, value = 0 },
};
}
// displays the players attributes for each stat in the spector with the use of values
[Serializable]
public struct Attribute
{
    public float currentValue;
    public float maxValue;
    public float value;
}
[Serializable]
public struct Stat
{
    public string name;
    public int statValue;
    public int value;
}