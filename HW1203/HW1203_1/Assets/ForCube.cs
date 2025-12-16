using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForCube : MonoBehaviour
{
    float[] position_x= {4.5f,-0.5f,-4.5f,0.5f};
    float[] position_z={-0.5f,-4.5f,0.5f,4.5f};
    float[] scale_x = {1f,9f,1f,9f};
    float[] scale_z = {9f,1f,9f,1f};
    Color[] colors = {
        Color.yellow,
        Color.red,
        Color.green,
        Color.blue
    };

    // Start is called before the first frame update
    void Start()
    {
        GenerateCube();
    }

    void GenerateCube(){
        for (int i = 0; i < 4; i++){
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(scale_x[i],1f,scale_z[i]);

            cube.transform.position = new Vector3(position_x[i], 0.5f, position_z[i]);

            Renderer renderer = cube.GetComponent<Renderer>();
            renderer.material.color = colors[i];

            cube.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
