using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somethingNew : MonoBehaviour
{
    public int rowCount = 10;
    public int colCount = 10;
    public float spacing = 1.0f;
    private PrimitiveType[] primitiveTypes = {
            PrimitiveType.Cube,
            PrimitiveType.Sphere,
            PrimitiveType.Capsule,
            PrimitiveType.Cylinder
        };
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Generate()
    {
        float startX = -(rowCount * spacing) / 2.0f + (spacing / 2.0f);
        float startZ = -(colCount * spacing) / 2.0f + (spacing / 2.0f);
        for (int i = 0; i <rowCount;i++){
            for (int ii = 0;ii<colCount;ii++){

                PrimitiveType selectedType = primitiveTypes[Random.Range(0, primitiveTypes.Length)];
                GameObject someShape = GameObject.CreatePrimitive(selectedType);

                Renderer renderer = someShape.GetComponent<Renderer>();
                renderer.material.color = GetRandomColor();
                Bounds bounds = renderer.bounds;

                float halfHeight = bounds.extents.y;
                Vector3 position = new Vector3(
                    startX + i * spacing,
                    halfHeight,
                    startZ + ii * spacing
                );
                someShape.transform.position = position;
                someShape.transform.SetParent(transform);
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
