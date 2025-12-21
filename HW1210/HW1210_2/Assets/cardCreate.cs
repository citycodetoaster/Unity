using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardCreate : MonoBehaviour
{
    private Sprite[] pokerSprites;
    // Start is called before the first frame update
    void Start()
    {
        pokerSprites = Resources.LoadAll<Sprite>("poker");
        if (pokerSprites == null || pokerSprites.Length == 0) {
            Debug.LogError("載入失敗，請確認圖片在 Resources 資料夾且 Sprite Mode 為 Multiple");
        }
        CreateCard();
    }
    void CreateCard(){
        for(int i=0;i<52;i++){
            GameObject card1 = new GameObject($"card_{i}_1");
            GameObject card2 = new GameObject($"card_{i}_2");
            card1.name = $"card_{i}_1";
            card2.name = $"card_{i}_2";
            Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f),Random.Range(0f, 5.0f),Random.Range(-5.0f, 5.0f));

            card1.AddComponent<SpriteRenderer>().sprite = pokerSprites[i];
            card2.AddComponent<SpriteRenderer>().sprite = pokerSprites[52];
            card2.transform.rotation = Quaternion.Euler(0, 180, 0);

            GameObject cardGroup = new GameObject($"Card_Group_{i}");
            cardGroup.transform.position = position;
            card1.transform.SetParent(cardGroup.transform);
            card2.transform.SetParent(cardGroup.transform);

            card1.transform.localPosition = Vector3.zero;
            card2.transform.localPosition = new Vector3(0, 0, 0.001f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
