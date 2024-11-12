using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFly : MonoBehaviour
{
    [SerializeField] private Transform Camera;
    private Rigidbody rb;
    public bool isFly;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        isFly = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFly)
        {
            rb.AddForce((Camera.forward * distance + Camera.position - rb.transform.position) * 2);
            if ((distance < 10.1) & (distance > 0.9)) distance = distance + 5 * Input.GetAxis("Mouse ScrollWheel");
            else
            {
                if (distance < 1) distance = 1;
                if (distance > 10) distance = 10;
            }
        }

    }
    public void Fly()
    {
        if (isFly)
        {
            rb.useGravity = true;
            rb.drag = 0;
            isFly = false;
            Debug.Log(isFly);
        }
        else
        {
            rb.useGravity = false;
            rb.drag = 5;
            isFly = true;
            Debug.Log(isFly);
            distance = Vector3.Distance(Camera.position, rb.position);
        }

    }
}
