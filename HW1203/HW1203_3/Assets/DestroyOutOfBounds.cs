using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float limitY = -10f;

    void Update()
    {
        // 檢查自己的 Y 軸座標
        if (transform.position.y < limitY)
        {
            // 刪除自己（這會連同底下的所有子物件 Ai 一起刪除）
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }
}
