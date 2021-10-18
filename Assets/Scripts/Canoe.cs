using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Canoe : MonoBehaviour
{
    public float pushForce = 1;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            rb.AddForceAtPosition(transform.forward * pushForce,
                rb.position + transform.right * .1f, ForceMode.Impulse);
        }
    }
}
