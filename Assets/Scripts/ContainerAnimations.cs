using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerAnimations : MonoBehaviour
{
    [SerializeField] ContainerCounter counter;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        counter.containerAnimation += Counter_containerAnimation;
    }

    private void Counter_containerAnimation(object sender, System.EventArgs e)
    {
        animator.SetTrigger("OpenClose");
    }
}
