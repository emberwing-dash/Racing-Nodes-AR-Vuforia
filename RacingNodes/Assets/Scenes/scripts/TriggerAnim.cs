using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnim : MonoBehaviour
{
    [SerializeField] Animator num1;
    [SerializeField] Animator num2;
    [SerializeField] Animator num3;
    [SerializeField] Animator num4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NUM1"))
        {
            StartCoroutine(PlayAndStop(num1, "num1"));
        }
        else if (other.CompareTag("NUM2"))
        {
            StartCoroutine(PlayAndStop(num2, "num2"));
        }
        else if (other.CompareTag("NUM3"))
        {
            StartCoroutine(PlayAndStop(num3, "num3"));
        }
        else if (other.CompareTag("NUM4"))
        {
            StartCoroutine(PlayAndStop(num4, "num4"));
        }
    }

    private IEnumerator PlayAndStop(Animator animator, string stateName)
    {
        animator.SetTrigger("Play");

        // Wait until the animator is in the right state
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(stateName));

        // Wait until it finishes
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        // Freeze at the last frame
        animator.speed = 0;
    }
}
