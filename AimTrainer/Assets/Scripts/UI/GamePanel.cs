using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Crosshair crosshair;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private PausePanel pausePanel;
    [SerializeField]
    private GameObject pauseBtn;

    void Start()
    {
        crosshair.Show();
#if UNITY_ANDROID
        pauseBtn.SetActive(true);
#endif
    }

#if UNITY_EDITOR || UNITY_STANDALONE
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
#endif

    public void OnPauseBtnClick()
    {
        Pause();
    }

    public void OnFireBtnClick()
    {
        gameManager.Fire();
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score : " + score;
    }

    private void Pause()
    {
        gameManager.Pause();
        pausePanel.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        crosshair.Hide();
    }
}
