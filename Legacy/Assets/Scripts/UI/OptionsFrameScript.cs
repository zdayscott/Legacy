using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsFrameScript : MonoBehaviour {

    public GameObject OptionsPanel;

    public void OpenMenu()
    {
        OptionsPanel.SetActive(true);
    }
    public void CloseMenu()
    {
        OptionsPanel.SetActive(false);
    }

}
