using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsFrameScript : MonoBehaviour {

    public GameObject OptionsPanel;
    public GameObject OptionsButtonOpen;
    public GameObject OptionsButtonClose;

    public void OpenMenu()
    {
        OptionsPanel.SetActive(true);
        OptionsButtonOpen.SetActive(false);
        OptionsButtonClose.SetActive(true);
    }
    public void CloseMenu()
    {
        OptionsPanel.SetActive(false);
        OptionsButtonOpen.SetActive(true);
        OptionsButtonClose.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OptionsPanel.gameObject.SetActive(!OptionsPanel.gameObject.activeSelf);
        }
    }
}
