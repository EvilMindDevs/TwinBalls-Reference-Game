using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenu : SimpleMenu<GameOverMenu>
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
    }

    public void Retry()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
