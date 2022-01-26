using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "Scriptable Object Asset/Skill Properties")]
public class SkillScript : ScriptableObject
{/* 0 = random, -1 = inf */
    public int popupStage;
    public int popupTile;
    public int durationStage;
    public int durationTile;

    public SkillType skillType;
}
public enum SkillType
{
     swap = 0,
    move = 1,
    flip = 2,
    bounce = 3,
    boss = 4,
}
