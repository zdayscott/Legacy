using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
public class EquiptmentSO : ItemSO {
    public EquimentType type;
    public int healthMod = 0;
    public float defenseMod = 0f;
    public float movementMod = 0f;


}

public enum EquimentType { Weapon, Helmet, Armor, Boots}
