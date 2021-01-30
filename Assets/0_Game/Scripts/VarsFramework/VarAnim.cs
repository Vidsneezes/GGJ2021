using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarAnim : MonoBehaviour
{
    [HideInInspector]
    public Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnim1()
    {
        animator.Play("1");
    }

    public void PlayAnim2()
    {
        animator.Play("1");
    }

    public void PlayAnim3()
    {
        animator.Play("1");
    }

    public void PlayAnim4()
    {
        animator.Play("1");
    }
}
