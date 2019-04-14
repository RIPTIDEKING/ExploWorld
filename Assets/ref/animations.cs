using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    private string state = "idle";
    private Animator animator;
    void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            state = "forward";
            animator.Play(state);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            state = "Left";
            animator.Play(state);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            state = "Right";
            animator.Play(state);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            state = "forward";
            animator.Play(state);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.DownArrow))
        {
            state = "idle";
            animator.Play(state);
        }
        
    }
}
