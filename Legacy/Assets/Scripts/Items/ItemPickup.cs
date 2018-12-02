using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
    public ItemSO item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PickUp();        
        }
    }

    void PickUp()
    {
        if(item == null)
        {
            Debug.LogWarning("No Item assigned to prefab: " + this.name);
            return;
        }

        Debug.Log("Pick Up " + item.name + "!");
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp)
        {
            Destroy(this.gameObject);
        }
    }
}
