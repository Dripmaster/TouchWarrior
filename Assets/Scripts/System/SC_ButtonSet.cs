using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ButtonSets", menuName = "Scriptable Object Asset/ButtonSets Properties")]
public class SC_ButtonSet : ScriptableObject
{
    public Sprite[] imgSet;
    public string setName;
    public Rarity rarity;
}
public enum Rarity
{
    common = 0,
    epic = 1,
    legendary =2,
}
 