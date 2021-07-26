using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseBall : MonoBehaviour
{
    private new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        transform.localScale = Vector3.zero;
        transform.DOScale(new Vector3(0.33f, 0.33f, 0.33f), 0.2f);
        transform.rotation = Quaternion.Euler(Random.Range(0, 359), Random.Range(0, 359), 0);
        rigidbody.velocity = transform.forward * Random.Range(Const.BALL_MIN_SPEED, Const.BALL_MAX_SPEED);
    }
}
