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

    public delegate void OnEquipt();
    public OnEquipt onEquiptCallback;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquimentType)).Length;
        currentEquiptment = new EquiptmentSO[numSlots];
    }

    public void Equip(EquiptmentSO newItem, EquimentType type)
    {
        Debug.Log(type);
        int index = (int)type;


        if(currentEquiptment[index] != null)
        {
            EquiptmentSO oldItem = currentEquiptment[index];
            Inventory.instance.Add(oldItem);
        }

        currentEquiptment[index] = newItem;

        Callback();
    }

    public void EquiptWeapon(WeaponSO weapon)
    {
        if (currentWeapon != null)
        {
            WeaponSO oldItem = currentWeapon;
            Inventory.instance.Add(oldItem);
        }

        currentWeapon = weapon;

        Callback();
    }

    public void Remove(ItemSO item)
    {
        if(item is WeaponSO)
        {
            currentWeapon = null;
        }
        else if(item is EquiptmentSO)
        {
            if(item is HelmetSO)
            {
                currentEquiptment[0] = null;
            }
            else if(item is ArmorSO)
            {
                currentEquiptment[1] = null;
            }
            else if(item is BootsSO)
            {
                currentEquiptment[2] = null;
            }
        }

        Callback();
    }

    void Callback()
    {
        if (onEquiptCallback != null)
        {
            onEquiptCallback.Invoke();
        }
    }
}
