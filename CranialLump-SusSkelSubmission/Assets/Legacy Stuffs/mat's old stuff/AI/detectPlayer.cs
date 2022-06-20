using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayer : MonoBehaviour
{
    public bool detected = false;
    public Transform pTransform;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") | other.CompareTag("Bullet") | other.CompareTag("Heavy Bullet") | other.CompareTag("Rocket"))
        {
            detected = true;
            pTransform = other.GetComponent<Transform>();
        }
    }
}
