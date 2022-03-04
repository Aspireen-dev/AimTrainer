using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    [SerializeField]
    private SettingsPanel settingsPanel;

    public void OnStartBtnClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnSettingsBtnClick()
    {
        settingsPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
