using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorControlScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigid;

    // Update is called once per frame
    void Update() 
    {
        animator.SetFloat("Velocity", rigid.velocity.magnitude);
    }
}
