using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private CrosshairPanel crosshairPanel;
    [SerializeField]
    private TargetPanel targetPanel;
    [SerializeField]
    private MenuPanel menuPanel;

    public void OnCrosshairBtnClick()
    {
        crosshairPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnTargetBtnClick()
    {
        targetPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnBackBtnClick()
    {
        menuPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
