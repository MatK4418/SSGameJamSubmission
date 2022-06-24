using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayer : MonoBehaviour
{
    public bool detected = false;
    public Transform pTransform;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") | other.CompareTag("AutoBullet") | other.CompareTag("SingleBullet") | other.CompareTag("SpreadBullet"))
        {
            detected = true;
            pTransform = other.GetComponent<Transform>();
        }
    }
}
