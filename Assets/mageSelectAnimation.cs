using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mageSelectAnimation : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        animator.speed = 1f;
        Debug.Log("over");
    }

    void OnMouseExit()
    {
        animator.speed = 0f;

    }
}
