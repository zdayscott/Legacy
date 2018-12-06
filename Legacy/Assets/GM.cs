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

    private void Start()
    {
        currentFloor = 1;
        floorText.text = "Floor " + currentFloor;
    }

    private void Update()
    {
        floorText.text = "Floor " + currentFloor;
    }

    void LootDropper(Transform pos)
    {

    }
}
