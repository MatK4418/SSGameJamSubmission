using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedometer : MonoBehaviour
{
    private Rigidbody rb;
    public Transform pivotHand;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        var speed = rb.velocity.magnitude;
  
        pivotHand.localRotation = Quaternion.Euler(0f, 0f, speed * -10);
    }



}
