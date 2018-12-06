using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{

    [SerializeField]
    private Loot[] loot;

    private List<ItemSO> rolledItems = new List<ItemSO>();

    [SerializeField]
    private GameObject itemContainer;

    public GameObject RollLoot()
    {
        foreach(Loot item in loot)
        {
            int roll = Random.Range(0, 100);

            if(roll <= item.DropChance)
            {
                rolledItems.Add(item.Item);
            }
        }

        if(rolledItems.Count <= 0)
        {
            return null;
        }

        itemContainer.GetComponent<ItemPickup>().item = rolledItems[Random.Range(0, rolledItems.Count)];

        return itemContainer;
    }
}

[System.Serializable]
public class Loot
{
    [SerializeField]
    private ItemSO item;

    [SerializeField]
    private float dropChance;

    public ItemSO Item
    {
        get
        {
            return item;
        }
    }

    public float DropChance
    {
        get
        {
            return dropChance;
        }
    }
}
