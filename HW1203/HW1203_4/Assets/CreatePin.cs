using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePin : MonoBehaviour
{
public int pinCount = 20; // 釘柱數量
    public float tiltAngle = -15f; // 傾斜角度

    // Start is called before the first frame update
    void Start()
    {
        GeneratePins();
        transform.rotation = Quaternion.Euler(tiltAngle, 0, 0);
    }

    void GeneratePins()
        {
            // 假設 Plane 大小是預設的 10x10 (其局部座標範圍約為 -5 到 5)
            for (int i = 0; i < pinCount; i++)
            {
                GameObject pin = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

                // 1. 設定為子物件
                pin.transform.SetParent(this.transform);

                // 2. 設定局部座標 (在 Plane 上的隨機位置)
                // Y 設為 0.5 讓圓柱體一半在上一半在下，看起來像釘在上面
                float randomX = Random.Range(-4.5f, 4.5f);
                float randomZ = Random.Range(-4.5f, 4.5f);
                pin.transform.localPosition = new Vector3(randomX, 0.5f, randomZ);

                // 3. 調整釘柱大小 (細長一點)
                pin.transform.localScale = new Vector3(0.2f, 0.5f, 0.2f);

                // 4. 給釘柱隨機顏色以便觀察
                pin.GetComponent<Renderer>().material.color = Color.gray;
            }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
