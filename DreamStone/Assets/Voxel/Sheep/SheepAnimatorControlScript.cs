using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAnimatorControlScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigid;
    public float depreTimer;

    // Update is called once per frame
    void Update() 
    {
        animator.SetFloat("Velocity", rigid.velocity.magnitude);
        animator.SetBool("Jumping", rigid.velocity.y > 1f);

        if (rigid.velocity.magnitude < 0.1f)
        {
            depreTimer += Time.deltaTime;
        }
        else
        {
            depreTimer = 0;
        }
        animator.SetBool("Depre", depreTimer > 2f);
    }
}
