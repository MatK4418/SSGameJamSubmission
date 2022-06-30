using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayer : MonoBehaviour
{
    public bool detected = false;
    public Transform pTransform;

    [HideInInspector]
    public GameObject detectedPlayerObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            detected = true;
            pTransform = other.GetComponent<Transform>();
            detectedPlayerObject = other.gameObject;
        }

        else if (other.CompareTag("AutoBullet") | other.CompareTag("SingleBullet") | other.CompareTag("SpreadBullet"))
        {
            detected = true;
            pTransform = other.GetComponent<Transform>();
        }
    }
}
