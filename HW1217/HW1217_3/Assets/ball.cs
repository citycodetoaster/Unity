using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    float cylinderHeight = 1f;
    float ballSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] taggedBalls = GameObject.FindGameObjectsWithTag("ball");
            foreach (GameObject b in taggedBalls)
            {
                Destroy(b);
            }

            GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ball.tag="ball";
            ball.name="ball";
            ball.transform.localScale = new Vector3(cylinderHeight, cylinderHeight, cylinderHeight);
            ball.transform.position = new Vector3(0f,cylinderHeight/2.0f,-5f);

            Rigidbody rb = ball.AddComponent<Rigidbody>();
            rb.velocity = Vector3.forward * ballSpeed;
            rb.mass=10f;
        }
    }
}
