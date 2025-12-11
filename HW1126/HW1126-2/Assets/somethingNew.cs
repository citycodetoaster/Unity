using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somethingNew : MonoBehaviour
{
    public int rowCount = 10;
    public int colCount = 10;
    public float spacing = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        GenerateSpheres();
    }

    void GenerateSpheres()
    {
        float startX = -(rowCount * spacing) / 2.0f + (spacing / 2.0f);
        float startZ = -(colCount * spacing) / 2.0f + (spacing / 2.0f);
        for (int i = 0; i <rowCount;i++){
            for (int ii = 0;ii<colCount;ii++){
                Vector3 position = new Vector3(
                    startX + i * spacing,
                    0.5f,
                    startZ + ii * spacing
                );
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = position;

                Renderer renderer = sphere.GetComponent<Renderer>();
                renderer.material.color = GetRandomColor();

                sphere.transform.SetParent(transform);
            }
        }
    }
    Color GetRandomColor()
    {
        // 隨機產生 R, G, B 值
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }
    // Update is called once per frame
    void Update()
    {

    }
}
