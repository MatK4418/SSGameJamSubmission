using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimTrigger : MonoBehaviour
{
    private bool isPlayerNearby = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("playerIsNearby", isPlayerNearby);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNearby = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNearby = false;
    }

    //https://docs.unity3d.com/Manual/AnimationParameters.html
    //https://www.youtube.com/watch?v=tJiO4cvsHAo
}
