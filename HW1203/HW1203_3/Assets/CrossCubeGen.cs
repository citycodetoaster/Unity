using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossCubeGen : MonoBehaviour
{
    private readonly Vector3 PieceScale = new Vector3(1f, 1f, 3f);
    private readonly Quaternion[] RelativeRotations = new Quaternion[]
    {
        Quaternion.identity,             // A1: 沿 Z 軸
        Quaternion.Euler(0, 90, 0),      // A2: 沿 X 軸
        Quaternion.Euler(90, 0, 0)       // A3: 沿 Y 軸
    };
    void Start()
    {
    }

    void Update()
    {
        // 每次按空白鍵，生成一個全新的 B (十字架)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateNewCross();
        }
    }
    private void CreateNewCross()
    {
        // 1. 建立一個全新的 GameObject 作為 B (Bi)
        GameObject crossB = new GameObject("Cross_B");

        // 2. 設定 Bi 的隨機世界位置
        crossB.transform.position = new Vector3(
            Random.Range(-5f, 5f),
            Random.Range(5f, 10f),
            Random.Range(-5f, 5f)
        );

        // 3. 為 Bi 加入 Rigidbody，讓它成為一個整體的物理單位
        Rigidbody rb = crossB.AddComponent<Rigidbody>();
        rb.useGravity = true;

        crossB.AddComponent<DestroyOutOfBounds>();//刪除

        // 4. 在這個 Bi 底下生成三個 Ai
        for (int i = 0; i < 3; i++)
        {
            GameObject pieceA = GameObject.CreatePrimitive(PrimitiveType.Cube);

            // 移除 A 自己的 Rigidbody，確保碰撞計算由父物件 B 統一處理
            if (pieceA.TryGetComponent<Rigidbody>(out Rigidbody childRB))
            {
                Destroy(childRB);
            }

            // 【關鍵點】：設定 A 的父物件為當前的 B
            pieceA.transform.SetParent(crossB.transform);

            // 【關鍵點】：相對位置設為 (0,0,0)，這樣 Ai 永遠鎖定在 Bi 的中心
            pieceA.transform.localPosition = Vector3.zero;
            
            // 設定相對旋轉
            pieceA.transform.localRotation = RelativeRotations[i];
            
            // 設定縮放
            pieceA.transform.localScale = PieceScale;

            // 隨機顏色
            pieceA.GetComponent<Renderer>().material.color = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
        }
    }
}