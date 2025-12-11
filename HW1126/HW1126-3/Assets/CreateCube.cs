using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    private readonly Vector3 cubeSize = new Vector3(2f, 0.25f, 2f);
    private readonly float thickness = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        int stackCount = 30;
        float angleIncrement = 3f;
        StackSomeCubes(stackCount, angleIncrement);
    }

    void StackSomeCubes(int count, float angle){
        for (int i = 0; i < count; i++){
            float positionY = i * thickness + (thickness / 2f);
            float rotationY = i * angle;

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = cubeSize;

            cube.transform.position = new Vector3(0f, positionY, 0f);
            cube.transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

            Renderer renderer = cube.GetComponent<Renderer>();
            renderer.material.color = GetRandomColor();

            cube.transform.SetParent(transform);
        }
    }

    Color GetRandomColor()
    {
        // 產生一個完全隨機的顏色 (R, G, B 各自在 0 到 1 之間隨機)
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
