using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private float distance;
    private GameObject current;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(CameraTransform.position, CameraTransform.position + CameraTransform.forward * 10);
        if (Input.GetMouseButtonDown(0))
        {
            if (current != null)
            {
                current.GetComponent<ObjectFly>().Fly();
                current = null;
            }
            else
            {
                if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out RaycastHit hit, distance, LayerMask.GetMask("Default")))
                {
                    if (hit.transform.tag == "Object")
                    {
                        current = hit.collider.gameObject;
                        current.GetComponent<ObjectFly>().Fly();
                        Debug.Log(hit.collider.gameObject.name);
                    }


                }
            }
            
        }
    }
}
