using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyActivator : MonoBehaviour
{
    public KeyCode collapseKey = KeyCode.Space;
    private bool hasCollapsed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(collapseKey) && !hasCollapsed)
        {
            ActivateRigidbodies();
            hasCollapsed = true;
        }
    }
    void ActivateRigidbodies(){
    
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<Rigidbody>();
        }

        Debug.Log("牆面已啟動 Rigidbody，開始崩塌！");
    }
}
