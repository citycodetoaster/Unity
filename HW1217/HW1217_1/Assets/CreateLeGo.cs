using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLeGo : MonoBehaviour
{
    public GameObject blockPrefab;
    public int layers = 5;
    public Vector3 blockSize = new Vector3(3f, 1f, 1f);
    // Start is called before the first frame update
    private Texture2D texStone1;
    private Texture2D texStone2;
    void Start()
    {
        texStone1 = Resources.Load<Texture2D>("stone-1");
        texStone2 = Resources.Load<Texture2D>("stone-2");
        GenerateTower();
    }
    void GenerateTower()
    {
        for (int y = 0; y < layers; y++)
        {
            // 判斷奇偶層，決定旋轉方向
            bool isEven = y % 2 == 0;
            Texture2D selectedTex = isEven ? texStone1 : texStone2;
            for (int i = 0; i < 3; i++) // 每層 3 根
            {
                GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                block.name = $"Block_{y}_{i}";

                block.transform.localScale = blockSize;
                // 計算每根積木的偏移量，使其併攏中心
                float offset = (i - 1) * blockSize.z;

                Vector3 position;
                Quaternion rotation;

                if (isEven)
                {
                    // 橫向擺放
                    position = new Vector3(0, y * blockSize.y, offset);
                    rotation = Quaternion.identity;
                }
                else
                {
                    // 縱向擺放 (旋轉 90 度)
                    position = new Vector3(offset, y * blockSize.y, 0);
                    rotation = Quaternion.Euler(0, 90, 0);
                }
                position.y += 0.5f;
                Renderer rend = block.GetComponent<Renderer>();
                rend.material.mainTexture = selectedTex;
                block.transform.position = position;
                block.transform.rotation = rotation;
                block.transform.parent = transform;
                // 生成積木
                Rigidbody rb = block.AddComponent<Rigidbody>();
                rb.mass = 0.5f; // 設定重量
                rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // 防止穿透
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name.StartsWith("Block_"))
                {
                    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        // 1. 取得積木目前的長軸方向
                        // 預設 Cube 長度在 X 軸 (blockSize.x = 3)
                        // 所以 transform.right 就是積木的長邊方向
                        Vector3 longAxis = hit.collider.transform.right;

                        // 2. 判斷正負方向：看滑鼠點擊的方向與長軸的夾角
                        // 如果射線方向與長軸點積為正，往長軸正向推，否則反向
                        float dot = Vector3.Dot(ray.direction, longAxis);
                        Vector3 pushDirection = (dot > 0) ? longAxis : -longAxis;

                        // 3. 計算推力
                        // 假設我們要讓積木在極短時間內移動 1/3 的長度 (例如 1 單位)
                        // 使用 VelocityChange 模式，力的大小即為速度 (v = d / t)
                        // 這裡給一個適當的衝量數值
                        float moveAmount = blockSize.x / 3f;
                        float forceMultiplier = 5f; // 調整此係數來控制「推」的感覺

                        rb.AddForce(pushDirection * moveAmount * forceMultiplier, ForceMode.VelocityChange);
                    }
                }
            }
        }
    }
}
