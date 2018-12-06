using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GM : MonoBehaviour
{
    #region Singleton
    public static GM instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one GM Found!!!");
        }
        instance = this;
    }

    #endregion

    public int currentFloor;
    public TMPro.TMP_Text floorText;

    public Transform LSpawnLoc;
    public LegacyWeaponSO wep;
    public GameObject itemContainer;

    private void Start()
    {
        currentFloor = 1;
        floorText.text = "Floor " + currentFloor;
        itemContainer.GetComponent<ItemPickup>().item = wep;
        Vector3 loc = new Vector3(LSpawnLoc.position.x, LSpawnLoc.position.y, LSpawnLoc.position.z);
        Quaternion rot = Quaternion.identity;
        Instantiate(itemContainer, loc, rot);
    }

    private void Update()
    {
        floorText.text = "Floor " + currentFloor;
    }

    void LootDropper(Transform pos)
    {

    }
}
