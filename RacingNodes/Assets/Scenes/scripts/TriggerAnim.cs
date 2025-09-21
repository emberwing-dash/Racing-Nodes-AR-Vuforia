using System.Collections;
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
            StartCoroutine(PlayAndReturn(num1, "num1"));
        else if (other.CompareTag("NUM2"))
            StartCoroutine(PlayAndReturn(num2, "num2"));
        else if (other.CompareTag("NUM3"))
            StartCoroutine(PlayAndReturn(num3, "num3"));
        else if (other.CompareTag("NUM4"))
            StartCoroutine(PlayAndReturn(num4, "num4"));
    }

    private IEnumerator PlayAndReturn(Animator animator, string stateName)
    {
        // Store current state
        int prevStateHash = animator.GetCurrentAnimatorStateInfo(0).shortNameHash;

        // Play target animation
        animator.SetTrigger("Play");

        // Wait until the animator enters the target state
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(stateName));

        // Wait until the animation finishes
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        // Reset speed in case it was modified
        animator.speed = 1;

        // Return to previous state
        animator.Play(prevStateHash, 0, 0);
    }
}
