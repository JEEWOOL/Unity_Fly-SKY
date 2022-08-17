using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    GameObject player;
    Vector3 dir;

    // 폭발공장주소
    public GameObject explosionFactory;

    void Start()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            int random = Random.Range(0, 100);

            if (random < 50)
            {
                dir = player.transform.position - transform.position;
                dir.Normalize();
            }
            else
            {
                dir = Vector3.down;
            }
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        // 방향을 구한다.
        //Vector3 dir = Vector3.down;

        // 이동하는 공식 : P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;

    }

    // 적이 다른 물체와 충돌
    private void OnCollisionEnter(Collision other)
    {
        // 적을 잡을 때마다 현재점수 표시
        ScoreManager.instance.Score++;

        // 폭발 효과 공장에서 폭발 효과를 하나 만든다.
        GameObject explosion = Instantiate(explosionFactory);

        // 폭발 효과 발생위치
        explosion.transform.position = transform.position;

        // 부딪힌 물체가 총알이라면
        if (other.gameObject.name.Contains("Bullet"))
        {
            // 부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);

            PlayerShot player = GameObject.Find("Player").
                GetComponent<PlayerShot>();

            // 리스트에 총알 삽입
            player.bulletObjectPool.Add(other.gameObject);
        }

        // 부딪힌 물체가 총알이 아니라면 제거
        else
        {
            // 적사망
            Destroy(other.gameObject);
        }

        EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        // 리스트에 총알 삽입
        manager.enemyObjectPool.Add(gameObject);

        // 총알사라짐        
        gameObject.SetActive(false);
    }
}
