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
            instance = this;
        }
    }

    #endregion

    EquiptmentSO[] currentEquiptment;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquimentType)).Length;
        currentEquiptment = new EquiptmentSO[numSlots];
    }

    public void Equip(EquiptmentSO newItem, EquimentType type)
    {
        int index = (int)type;

        currentEquiptment[index] = newItem;
    }
}
