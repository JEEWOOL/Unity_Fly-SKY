using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 플레이어가 이동할 속력
    public float speed = 5;
    void Start()
    {
        
    }

    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //print("h : " + h + ", v : " + v);

        //Vector3 dir = Vector3.right * h + Vector3.up * v;
        Vector3 dir = new Vector3(h, v, 0);

        if (dir.magnitude > 1)
        {
            dir.Normalize();
        }

        //transform.Translate(Vector3.left * speed * Time.deltaTime);
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0)
        {
            pos.x = 0;
        }
        if (pos.x > 1)
        {
            pos.x = 1;
        }
        if (pos.y < 0)
        {
            pos.y = 0;
        }
        if (pos.y > 1)
        {
            pos.y = 1;
        }

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
