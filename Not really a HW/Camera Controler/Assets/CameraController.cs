using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject targetCam;
    public float moveSpeed = 12f;
    public float smoothness = 0.125f;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
        }
        targetCam = GameObject.Find("Camera_test");
        if (targetCam == null)
        {
            Debug.LogError("找不到名為 'Camera_test' 的物件！請檢查 Hierarchy 中的名稱。");
        }
        else
        {
            targetPosition = targetCam.transform.position;
        }
        targetCam.GetComponent<Camera>().targetDisplay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCam == null) return;
        Movement();
    }

    void Movement(){
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = (targetCam.transform.forward * v + targetCam.transform.right * h).normalized;
        targetPosition += moveDir * moveSpeed * Time.deltaTime;
        targetCam.transform.position = Vector3.Lerp(targetCam.transform.position, targetPosition, smoothness);
    }
}
