using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one EquiptmentManager Found!!!");
        }
        instance = this;
    }

    #endregion

    public EquiptmentSO[] currentEquiptment;
    public WeaponSO currentWeapon;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquimentType)).Length;
        currentEquiptment = new EquiptmentSO[numSlots];
    }

    public void Equip(EquiptmentSO newItem, EquimentType type)
    {
        int index = (int)type;

        if(currentEquiptment[index] != null)
        {
            EquiptmentSO oldItem = currentEquiptment[index];
            Inventory.instance.Add(oldItem);
        }

        currentEquiptment[index] = newItem;
    }

    public void EquiptWeapon(WeaponSO weapon)
    {
        if (currentWeapon != null)
        {
            WeaponSO oldItem = currentWeapon;
            Inventory.instance.Add(oldItem);
        }

        currentWeapon = weapon;
    }
}
