using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject bulletFactory;    

    // 탄창에 넣을 수 있는 총알의 개수
    public int poolSize = 1000;

    // 오브젝트 풀 배열
    public List<GameObject> bulletObjectPool;

    
    private void Start()
    {
        // 탄창을 총알을 담을수 있는 크기로 만든다.
        bulletObjectPool = new List<GameObject>();

        // 탄창에 넣을 총알 개수만큼 반복
        for (int i = 0; i < poolSize; i++)
        {
            // 총알 공장에서 총알 생성
            GameObject bullet = Instantiate(bulletFactory);

            // 총알을 오브젝트 풀에 넣고 싶다.
            bulletObjectPool.Add(bullet);

            // 비활성화 시키기
            bullet.SetActive(false);
        }

        // 실행되는 플랫폼이 안드로이드일 경우 조이스틱을 활성화 시킨다.
        #if UNITY_ANDROID
            GameObject.Find("Joystick canvas XYBZ").SetActive(true);
        #elif UNITY_EDITOR || UNITY_STANDALONE
            GameObject.Find("Joystick canvas XYBZ").SetActive(false);
        #endif
    }

    void Update()
    {
        // 유니티 데이터와 PC환경일때 작동한다.
#if UNITY_EDITOR || UNITY_STANDALONE
        // 발사 버튼을 누른다.
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
        // 탄창 안에 있는 총알이 있다면
        if (bulletObjectPool.Count > 0)
        {
            // 비활성화 된 총알을 하나 가져온다.
            GameObject bullet = bulletObjectPool[0];

            // 총알을 발사하고 싶다.(활성화시킨다.)
            bullet.SetActive(true);

            // 오브젝트풀에서 총알 제거
            bulletObjectPool.Remove(bullet);

            // 총알을 위치 시키기
            bullet.transform.position = transform.position;
        }
    }
}
