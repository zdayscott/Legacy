using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentFrameScript : MonoBehaviour
{

    public GameObject EquipmentPanel;

    public void OpenMenu()
    {
        EquipmentPanel.SetActive(true);
    }
    public void CloseMenu()
    {
        EquipmentPanel.SetActive(false);
    }

}