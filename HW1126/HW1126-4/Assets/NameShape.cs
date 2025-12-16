using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameShape : MonoBehaviour
{
    public const bool BOOL_0 = false;
    public const bool BOOL_1 = true;
    public float spacing = 1.0f;
    public Color nameColor = Color.red;
    public bool[,] name_bool={
    {BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,},
    {BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,},
    {BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_0,},
    {BOOL_0,BOOL_1,BOOL_1,BOOL_0,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_1,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,},
    {BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_0,},
    {BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,},
    {BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_1,BOOL_1,BOOL_0,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_0,},
    {BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_1,BOOL_0,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_0,},
    {BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_1,BOOL_1,BOOL_1,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_0,BOOL_0,},
    {BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_1,BOOL_0,BOOL_0,BOOL_1,BOOL_0,BOOL_1,BOOL_0,BOOL_0,BOOL_1,BOOL_1,BOOL_1,BOOL_0,},
    {BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,BOOL_0,},
    };
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateNameWall();
    }

    void GenerateNameWall(){
        int wallWidth = name_bool.GetLength(1);
        int wallHeight = name_bool.GetLength(0);

        float startX = -(wallWidth * spacing) / 2.0f + (spacing / 2.0f);
        float startY = (wallHeight * spacing) - (spacing / 2.0f);

        for (int x = 0; x<wallWidth; x++){
            for(int y=0; y<wallHeight;y++){
                Vector3 position = new Vector3(
                    startX + x * spacing,
                    startY - y * spacing,
                    0f
                );
                bool isNamePart = name_bool[y,x];
                GameObject primitive;
                Color objectColor;
                if(isNamePart){
                    primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    objectColor = nameColor;
                }
                else{
                    primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    objectColor = GetRandomColor();
                }
                primitive.transform.position = position;
                primitive.GetComponent<Renderer>().material.color = objectColor;
                primitive.transform.SetParent(transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Color GetRandomColor()
    {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }
}
