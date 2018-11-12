using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFrameScript : MonoBehaviour {

    public GameObject MapPanel;
    public GameObject MapButtonOpen;
    public GameObject MapButtonClose;

    public void OpenMenu()
    {
        MapPanel.SetActive(true);
        MapButtonOpen.SetActive(false);
        MapButtonClose.SetActive(true);
    }
    public void CloseMenu()
    {
        MapPanel.SetActive(false);
        MapButtonOpen.SetActive(true);
        MapButtonClose.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MapPanel.gameObject.SetActive(!MapPanel.gameObject.activeSelf);
        }
    }
}
