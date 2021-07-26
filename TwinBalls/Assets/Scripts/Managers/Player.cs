using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float angle = 300f;

    private float defaultBallDistance = 1.8f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameManager.Instance.IsGameStarted) return;
            angle *= -1;
        }
        if (Application.isEditor)
            transform.Rotate(0, 0, angle * Const.TURNING_SPEED * Time.deltaTime);
        else
            transform.Rotate(0, 0, angle * HMSRemoteConfigManager.Instance.GetValueAsFloat("TURNING_SPEED") * Time.deltaTime);
    }
}
