using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffSet = 1f;
    public Transform ball;

    private void Update()
    {
        Vector3 newPOS = new Vector3(ball.position.x, ball.position.y + yOffSet, -10f);
        transform.position = Vector3.Slerp(transform.position, newPOS, followSpeed * Time.deltaTime);
    }
}
