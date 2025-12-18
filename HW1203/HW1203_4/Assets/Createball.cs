using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createball : MonoBehaviour
{
    public Transform planeTransform;
    // Start is called before the first frame update
    void Start()
    {
        if (planeTransform == null)
        {
            GameObject foundPlane = GameObject.Find("Plane");
            if (foundPlane != null)
            {
                Debug.Log("<color=green>● 成功找到 Plane！</color>");
                planeTransform = foundPlane.transform;
            }
            else
            {
                Debug.LogError("找不到名為 'Plane' 的物件，請確認場景中物件名稱是否正確！");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("<color=yellow>鍵盤空白鍵已按下</color>");
            if (planeTransform != null)
            {
                SpawnBall();
            }
            else
            {
                Debug.LogWarning("因為 planeTransform 是空的，所以沒辦法生球！");
            }
        }
    }
    void SpawnBall()
    {
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // 設定球的大小
        ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // 設定生成位置：在 Plane 的上方邊緣
        // 我們利用 Plane 的 position 加上一點偏移
        Vector3 startPos = planeTransform.position + new Vector3(Random.Range(-4.5f, 4.5f), 5f, 4f);
        ball.transform.position = startPos;

        // 加入物理組件
        Rigidbody rb = ball.AddComponent<Rigidbody>();
        rb.mass = 1f;

        Debug.Log("<color=cyan>成功生成球：" + ball.name + " 位置：" + startPos + "</color>");
        // 加入自動刪除腳本 (或者是直接在這裡寫一個簡單的偵測)
        BallDestruction dest = ball.AddComponent<BallDestruction>();
    }
}

public class BallDestruction : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
            Debug.Log("<color=cyan>成功刪除球</color>");
        }
    }
}