using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        // 위로가는 방향
        Vector3 dir = Vector3.up;

        // 이동할 공식 = P = P0 + vt
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
