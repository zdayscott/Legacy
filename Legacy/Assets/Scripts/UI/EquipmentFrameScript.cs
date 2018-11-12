using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentFrameScript : MonoBehaviour
{

    public GameObject EquipmentPanel;
    public GameObject EquipmentButtonOpen;
    public GameObject EquipmentButtonClose;

    public void OpenMenu()
    {
        EquipmentPanel.SetActive(true);
        EquipmentButtonOpen.SetActive(false);
        EquipmentButtonClose.SetActive(true);
    }
    public void CloseMenu()
    {
        EquipmentPanel.SetActive(false);
        EquipmentButtonOpen.SetActive(true);
        EquipmentButtonClose.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            EquipmentPanel.gameObject.SetActive(!EquipmentPanel.gameObject.activeSelf);
        }
    }
}