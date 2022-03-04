using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public void OnUnpauseBtnClick()
    {
        gameManager.Unpause();
        gameObject.SetActive(false);
    }

    public void OnMenuBtnClick()
    {
        gameManager.BackToMenu();
    }
}
