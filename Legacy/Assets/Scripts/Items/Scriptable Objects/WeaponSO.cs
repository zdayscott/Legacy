using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class WeaponSO : ItemSO
{
    public int damage = 0;
    public float attackSpeed = 0f;
    public int type = 3; // Hard Coded index of Equiptment Array
    //public GameObject attackCollider;
}
