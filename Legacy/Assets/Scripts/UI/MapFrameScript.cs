using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFrameScript : MonoBehaviour {

    public GameObject MapPanel;

    public void OpenMenu()
    {
        MapPanel.SetActive(true);
    }
    public void CloseMenu()
    {
        MapPanel.SetActive(false);
    }

}
