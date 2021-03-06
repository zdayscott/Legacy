﻿using UnityEngine;
using UnityEngine.UI;



public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;
    public Button equiptButton;

    ItemSO item;

    public float dropOffset = 100f;

    public bool isEquiptmentPanel = false;


    public void AddItem(ItemSO newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.gameObject.SetActive(true);
        removeButton.gameObject.SetActive(true);
        if((item is WeaponSO || item is EquiptmentSO) && !isEquiptmentPanel)
        {
            equiptButton.gameObject.SetActive(true);
        }
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        removeButton.gameObject.SetActive(false);
        if(equiptButton != null)
        {
            equiptButton.gameObject.SetActive(false);
        }

    }

    public void OnRemoveButton()
    {
        if(!isEquiptmentPanel)
        {
            ItemSO dropItem = item;
            Inventory.instance.Remove(item);
            ClearSlot();

            SpawnItem(dropItem);
        }else
        {
            Debug.Log("De-Equip");
            ItemSO dropItem = item;
            EquipmentManager.instance.Remove(item);
            ClearSlot();

            if(!Inventory.instance.Add(dropItem))
            {
                SpawnItem(dropItem);
            }
        }
    }

    void SpawnItem(ItemSO item)
    {
        // REFAC: SpawnItem
        Transform itemDropLoc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().itemDropLoc;

        Vector3 itemDropPos = itemDropLoc.position;
        Quaternion itemDropRot = itemDropLoc.rotation;

        GameObject droppedItem = Instantiate(Inventory.instance.inGameitemPrefab, itemDropPos, itemDropRot);
        droppedItem.GetComponent<ItemPickup>().item = item;
    }

    public void OnEquiptButton()
    {
        if(item is WeaponSO)
        {
            Inventory.instance.EquiptWeapon(item as WeaponSO);
        }
        else if (item is HelmetSO || item is ArmorSO || item is BootsSO)
        {
            Inventory.instance.Equip(item as EquiptmentSO);
        }
        else
        {
            Debug.Log("Not Equiptable!!!");
        }
    }

    public void UseItem()
    {
        if (item != null)
        {
            //item.Use();
        }
    }
}