using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject equiptmentParent;
    Inventory inventory;
    EquipmentManager equipmentManager;

    InventorySlot[] slots;
    InventorySlot[] equiptmentSlots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        equipmentManager = EquipmentManager.instance;
        inventory.onItemChangedCallback += UpdateUi;
        inventory.onEquiptCallback += UpdateEquiptmentUi;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        equiptmentSlots = equiptmentParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUi()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void UpdateEquiptmentUi()
    {
        for (int i = 0; i < equiptmentSlots.Length - 1; i++)
        {
            if (equipmentManager.currentEquiptment[i] != null)
            {
                equiptmentSlots[i].AddItem(equipmentManager.currentEquiptment[i]);
            }
            else
            {
                equiptmentSlots[i].ClearSlot();
            }
        }

        if(equipmentManager.currentWeapon != null)
        {
            Debug.Log("Attempting to Show Weapon!");
            equiptmentSlots[3].AddItem(equipmentManager.currentWeapon);
        }
        else
        {
            equiptmentSlots[3].ClearSlot();
        }
    }
}
