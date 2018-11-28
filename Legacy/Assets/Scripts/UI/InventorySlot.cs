using UnityEngine;
using UnityEngine.UI;



public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;

    ItemSO item;
    public void AddItem(ItemSO newItem)
    {
        Debug.Log("Updating Slot");
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
        Inventory.instance.Remove(item);
        ClearSlot();
    }

    public void UseItem()
    {
        if (item != null)
        {
            //item.Use();
        }
    }
}