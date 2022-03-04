using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GamePanel gamePanel;
    [SerializeField]
    private EndGamePanel endGamePanel;
    [SerializeField]
    private TargetSpawner targetSpawner;
    [SerializeField]
    private Gun gun;

    private int score = 0;
    private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        gamePanel.UpdateScoreText(score);
        Unpause();
    }

#if UNITY_EDITOR || UNTIY_STANDALONE
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
#endif

    public void Fire()
    {
        if (isPlaying)
        {
            gun.Fire();
        }
    }

    public void TargetHit(float targetSize)
    {
        int points = Mathf.RoundToInt((5.05f - targetSize) * 50);
        UpdateScore(points);
        targetSpawner.TargetHit();
    }

    public void TargetMissed()
    {
        UpdateScore(-100);
    }

    public void EndGame()
    {
        Pause();

        int bestScore = PlayerPrefs.GetInt("bestScore", 0);
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        endGamePanel.gameObject.SetActive(true);
        endGamePanel.ShowFinalScoreText(score, bestScore);
    }

    public void Pause()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        UnlockCursor();
#endif
        isPlaying = false;
        Time.timeScale = 0;
    }
    public void Unpause()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        LockCursor();
#endif
        isPlaying = true;
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        if (score < 0) score = 0;
        gamePanel.UpdateScoreText(score);
    }

    private void OnDestroy()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        UnlockCursor();
#endif
        Time.timeScale = 1;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
