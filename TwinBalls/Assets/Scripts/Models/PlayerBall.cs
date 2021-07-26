using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Const.TAG_ENEMY))
        {
            GameManager.Instance.GameOver();
            Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);
        }
        else if (other.gameObject.CompareTag(Const.TAG_FRIENDLY))
        {
            int ballScore = Application.isEditor ? Const.BALL_SCORE : HMSRemoteConfigManager.Instance.GetValueAsInt("BALL_SCORE");
            GameManager.Instance.IncreaseScore(ballScore);
            Destroy(other.gameObject);
        }
    }
}
