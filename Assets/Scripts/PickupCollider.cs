using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupCollider : MonoBehaviour
{
    private int count = 0;
    [SerializeField] private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Object")
        {
            count++;
            text.text = "Collected " + count.ToString() + "/3";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Object")
        {
            count--;
            text.text = "Collected " + count.ToString() + "/3";
        }
    }
}
