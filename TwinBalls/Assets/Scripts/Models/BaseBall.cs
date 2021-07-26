using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseBall : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private float ballMinSpeed;
    private float ballMaxSpeed;

    void Start()
    {
        ballMinSpeed = Application.isEditor ? Const.BALL_MIN_SPEED : HMSRemoteConfigManager.Instance.GetValueAsFloat("BALL_MIN_SPEED");
        ballMaxSpeed = Application.isEditor ? Const.BALL_MAX_SPEED : HMSRemoteConfigManager.Instance.GetValueAsFloat("BALL_MAX_SPEED");
        rigidbody = GetComponent<Rigidbody>();
        transform.localScale = Vector3.zero;
        transform.DOScale(new Vector3(0.33f, 0.33f, 0.33f), 0.2f);

        transform.rotation = Quaternion.Euler(Random.Range(0, 359), Random.Range(0, 359), 0);
        rigidbody.velocity = transform.forward * Random.Range(ballMinSpeed, ballMaxSpeed);
    }
}
