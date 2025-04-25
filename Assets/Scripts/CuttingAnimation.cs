using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingAnimation : MonoBehaviour
{
    [SerializeField] CuttingCounter cuttingCounter;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        cuttingCounter.OnCutAnimations += CuttingCounter_OnCutAnimations;
    }

    private void CuttingCounter_OnCutAnimations(object sender, System.EventArgs e)
    {
        animator.SetTrigger("Cut");
    }
}
