using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // 배경 머터리얼
    public Material bgMaterial;

    // 스크롤 속도
    public float scrollSpeed = 0.2f;

    // 살아 있는 동안 반복한다.
    private void Update()
    {
        // 방향
        Vector2 direction = Vector2.up;

        // 스크롤한다. P = P0 + vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
