using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roll : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float rotationDirection = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            // 將旋轉方向設定為與輸入方向相同
            rotationDirection = horizontalInput > 0 ? 1f : -1f;
        }
        if (rotationDirection != 0)
        {
            transform.Rotate(Vector3.up, rotationSpeed * rotationDirection * Time.deltaTime);
        }
    }
}
