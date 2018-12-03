using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public delegate void OnEquipt();
    public OnEquipt onEquiptCallback;


    [Header("General Inventory")]
    public List<ItemSO> items = new List<ItemSO>();

    public int space = 12;

    public GameObject inGameitemPrefab;

    EquipmentManager equipmentManager;

    private void Start()
    {
        equipmentManager = EquipmentManager.instance;
        if(equipmentManager == null)
        {
            Debug.Log("No EquiptmenManager found!!!");
        }
    }

    public bool Add(ItemSO item)
    {
        if(items.Count < space)
        {
            items.Add(item);
            // CallBack Triggered
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            return true;
        }
        else
        {
            //Inventory Full
            return false;
        }

    }

    public void Remove(ItemSO item)
    {
        items.Remove(item);

        // CallBack Triggered
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void Equip(EquiptmentSO eq)
    {
        equipmentManager.Equip(eq, eq.type);

        if(onEquiptCallback != null)
        {
            onEquiptCallback.Invoke();
        }

        Remove(eq);

    }

    public void EquiptWeapon(WeaponSO wep)
    {
        Debug.Log(wep);
        EquiptWep(wep);

        if (onEquiptCallback != null)
        {
            onEquiptCallback.Invoke();
        }

        Remove(wep);
    }

    private void EquiptWep(WeaponSO wep)
    {
        Debug.Log(wep);
        equipmentManager.EquiptWeapon(wep as WeaponSO);
    }
}
