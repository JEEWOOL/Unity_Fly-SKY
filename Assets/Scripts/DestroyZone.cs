using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // 영역안에 다른 물체가 감지될때
    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 물체가 총알이거나 적이라면
        if(other.gameObject.name.Contains("Bullet") ||
            other.gameObject.name.Contains("Enemy"))
        {
            // 부딪힌 물체 비활성화
            other.gameObject.SetActive(false);

            // 부딪힌 물체가 총알일 경우 총알리스트에 넣기
            if (other.gameObject.name.Contains("Bullet"))
            {
                PlayerShot player = GameObject.Find("Plater").
                GetComponent<PlayerShot>();

                // 리스트에 총알 삽입
                player.bulletObjectPool.Add(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Enemy"))
            {
                GameObject emObject = GameObject.Find("EnemyManager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>();

                // 리스트에 총알 삽입
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
    }
}
