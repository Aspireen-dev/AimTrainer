using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private TMP_Text finalScoreText;
    [SerializeField]
    private TMP_Text bestScoreText;

    public void ShowFinalScoreText(int score, int bestScore)
    {
        finalScoreText.text = "Final score : " + score;
        bestScoreText.text = "Best score : " + bestScore;
    }

    public void OnStartBtnClick()
    {
        gameManager.StartGame();
    }

    public void OnMenuBtnClick()
    {
        gameManager.BackToMenu();
    }

}
