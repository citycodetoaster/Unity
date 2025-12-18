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
                // 從攝影機發射一條射線到滑鼠點擊的位置
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // 執行射線檢測
                if (Physics.Raycast(ray, out hit))
                {
                    // 檢查點擊到的物件是否為積木 (根據名稱或標籤)
                    // 因為我們生成的積木名稱開頭都是 "Block_"
                    if (hit.collider.gameObject.name.StartsWith("Block_"))
                    {
                        // 刪除點擊到的積木
                        Destroy(hit.collider.gameObject);

                        // 可選：如果你希望點掉後周圍積木立刻有物理反應
                        // 可以增加一個微小的衝擊力，但 Destroy 通常就足以讓塔倒下了
                    }
                }
            }
    }
}
