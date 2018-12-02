using UnityEngine;
using UnityEngine.UI;



public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;

    ItemSO item;

    public float dropOffset = 100f;


    public void AddItem(ItemSO newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.gameObject.SetActive(true);
        removeButton.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        removeButton.gameObject.SetActive(false);
    }

    public void OnRemoveButton()
    {
        ItemSO dropItem = item;
        Inventory.instance.Remove(item);
        ClearSlot();
        Transform itemDropLoc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().itemDropLoc;

        Vector3 itemDropPos = itemDropLoc.position;
        Quaternion itemDropRot = itemDropLoc.rotation;

        GameObject droppedItem = Instantiate(Inventory.instance.inGameitemPrefab, itemDropPos, itemDropRot);
        droppedItem.GetComponent<ItemPickup>().item = dropItem;
    }

    public void UseItem()
    {
        if (item != null)
        {
            //item.Use();
        }
    }
}