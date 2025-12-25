using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    int CountLine=0;
    string[] map = {
        "0|00000|0000|",
        "-0---0--0-",
        "00|00|0000|00|",
        "----0-----",
        "00|00|00|0000|",
        "00----00--",
        "000|000|00|00|",
        "------0000",
        "|00|0000|0000|",
        "|0000|000|000|",
        "00|00|0000|00|",
        "----0-----",
        "00|00|00|0000|",
        "00---000--",
        "000|000|00|00|",
        "----0000--",
        "|00|0000|0000|",
        "----------",
    };
    // Start is called before the first frame update
    void Start()
    {
        CreateWall_function();
    }

    void CreateWall_function(){
        CountLine=0;
        foreach (string line in map) {
            Debug.Log(line);
            if (line.Contains("-") && line.Contains("|"))
            {
                Debug.LogError($"錯誤：找到 '-' 和 '|'！這行內容是無效資料: {line}");
            }
            else if(line.Contains("-")){
                CreateWall_Horiz(line);
            }
            else if(line.Contains("|")){
                CreateWall_Vert(line);
                CountLine++;
            }
            else
            {
                Debug.LogError($"錯誤：沒有找到 '-' 或 '|'！這行內容是空值或無效資料: {line}");
            }
        }
    }
    void CreateWall_Vert(string line){
        int CountZero = 0;
        foreach(char word in line){
            if(word=='0'){
                CountZero++;
            }
            else if(word=='|'){
                GameObject Wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Wall.transform.SetParent(this.transform);
                Wall.name = $"Wall_Vert_{CountLine}_{CountZero}";
                Wall.transform.localScale = new Vector3(0.1f, 1f, 0.9f);
                Wall.transform.localPosition = new Vector3(-5f+CountZero,0.5f,4.5f-CountLine);
            }
            else
            {
                Debug.LogError($"錯誤：找到了非 '0' 或 '|'！這行內容是空值或無效資料: {line}");
            }
        }
    }
    void CreateWall_Horiz(string line){
        int Count = 0;
        foreach(char word in line){
            if(word=='0'){
                Count++;
            }
            else if(word=='-'){
                GameObject Wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Wall.transform.SetParent(this.transform);
                Wall.name = $"Wall_Horiz_{CountLine}_{Count}";
                Wall.transform.localScale = new Vector3(0.9f, 1f, 0.1f);
                Wall.transform.localPosition = new Vector3(-4.5f+Count,0.5f,5f-CountLine);
                Count++;
            }
            else
            {
                Debug.LogError($"錯誤：找到了非 '0' 或 '-'！這行內容是空值或無效資料: {line}");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
