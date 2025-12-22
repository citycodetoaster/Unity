using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolo : MonoBehaviour
{
    float cylinderSize = 0.4f;
    float cylinderHeight = 1f;
    float cylinderDire = 1f;
    // Start is called before the first frame update
    void Start()
    {
        CreateBolo(10);
    }

    void CreateBolo(int n){
        int count = 0;
        for(int i=0;i<n;i+=count){
            count++;
            Vector3 position;
            for(int ii=0;ii<count;ii++){
                GameObject bolo = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                position = new Vector3(-(count-1)/2.0f*cylinderDire+ii*cylinderDire,cylinderHeight,count*(cylinderDire/2.0f*Mathf.Sqrt(3f))+1f);
                bolo.name=$"bolo_{count}_{ii+1}";
                bolo.transform.position = position;
                bolo.transform.localScale = new Vector3(cylinderSize, cylinderHeight, cylinderSize);

                Rigidbody rb = bolo.AddComponent<Rigidbody>();
                rb.mass=1.0f;
                rb.drag=0.5f;
                rb.angularDrag=0.5f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
