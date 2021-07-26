using HuaweiMobileServices.RemoteConfig;
using HuaweiMobileServices.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject friendPrefab;

    private System.Random random = new System.Random();
    public static bool gameAlreadyStarted;

    private int score;
    public int Score { get => score; set => score = value; }

    private bool isGameOver;
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

    public bool IsGameStarted;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
    }

    void Start()
    {
        Application.targetFrameRate = 300;
        if (!gameAlreadyStarted)
        {
            MainMenu.Show();
            gameAlreadyStarted = true;
#if !UNITY_EDITOR
            HMSRemoteConfigManager.Instance.OnFecthSuccess = OnFecthSuccess;
            HMSRemoteConfigManager.Instance.OnFecthFailure = OnFecthFailure;
            HMSRemoteConfigManager.Instance.Fetch(0);
#endif
        }
        else
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        IsGameStarted = true;
        GameMenu.Show();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        if (Application.isEditor)
        {
            yield return new WaitForSeconds(Const.SPAWN_START_WAIT);

            while (!IsGameOver)
            {
                if (random.NextDouble() < Const.ENEMY_SPAWN_CHANCE)
                {
                    Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Instantiate(friendPrefab, Vector3.zero, Quaternion.identity);
                }

                yield return new WaitForSeconds(Random.Range(Const.SPAWN_WAIT_MIN, Const.SPAWN_WAIT_MAX));
            }
        }

        else
        {
            yield return new WaitForSeconds(HMSRemoteConfigManager.Instance.GetValueAsFloat("SPAWN_START_WAIT"));

            while (!IsGameOver)
            {
                if (random.NextDouble() < HMSRemoteConfigManager.Instance.GetValueAsFloat("ENEMY_SPAWN_CHANCE"))
                {
                    Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Instantiate(friendPrefab, Vector3.zero, Quaternion.identity);
                }

                yield return new WaitForSeconds(Random.Range(HMSRemoteConfigManager.Instance.GetValueAsFloat("SPAWN_WAIT_MIN"), HMSRemoteConfigManager.Instance.GetValueAsFloat("SPAWN_WAIT_MAX")));
            }
        }
    }

    public void IncreaseScore(int value)
    {
        Score += value;
        GameMenu.Instance.UpdateScore(Score);
    }

    public void GameOver()
    {
        IsGameOver = true;
        GameOverMenu.Show();
    }

    private void OnFecthSuccess(ConfigValues config)
    {
        Debug.Log($"[GameManager]: fetch() Success");
    }

    private void OnFecthFailure(HMSException exception)
    {
        Debug.Log($"[GameManager]: fetch() Failed Error Code => {exception.ErrorCode} Message => {exception.WrappedExceptionMessage}");
    }
}
