using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class MainMenu : SimpleMenu<MainMenu>
{
    [SerializeField]
    private TextMeshProUGUI touchToStartLabel;

    private void OnEnable()
    {
        touchToStartLabel.DOFade(1, 0.6f).SetLoops(-1, LoopType.Yoyo).SetDelay(1.2f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.StartGame();
        }
    }
}
