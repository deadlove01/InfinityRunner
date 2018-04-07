using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{


    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public void Run()
    {
        anim.SetBool("Run", true);
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }

    public void Die()
    {
        anim.SetBool("Die", true);
    }

}
