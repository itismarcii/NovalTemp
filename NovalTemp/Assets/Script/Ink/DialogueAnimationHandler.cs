using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class DialogueAnimationHandler : MonoBehaviour
{
    public Animator animator { get; private set; }
    public RawImage image1;
    public RawImage image2;
    public RawImage image3;
    public RawImage image4;



    private void Awake()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("box_isIn", false);
        animator.SetBool("one_isIn", false);
        animator.SetBool("two_isIn", false);
        animator.SetBool("three_isIn", false);
        animator.SetBool("four_isIn", false);
    }

    public void DialogueStart()
    {
        animator.SetBool("box_isIn", true);
    }

    public void Animate(int imageNumber, bool isIn)
    {
        switch (imageNumber)
        {
            case 1:
                switch (isIn)
                {
                    case true:
                        animator.SetBool("one_isIn", isIn);
                        break;
                    case false:
                        StartCoroutine(OutDelay("one_isIn"));
                        break;
                }
                break;
            case 2:
                switch (isIn)
                {
                    case true:
                        animator.SetBool("two_isIn", isIn);
                        break;
                    case false:
                        StartCoroutine(OutDelay("two_isIn"));
                        break;
                }
                break;
            case 3:
                switch (isIn)
                {
                    case true:
                        animator.SetBool("three_isIn", isIn);
                        break;
                    case false:
                        StartCoroutine(OutDelay("three_isIn"));
                        break;
                }
                break;
            case 4:
                switch (isIn)
                {
                    case true:
                        animator.SetBool("four_isIn", isIn);
                        break;
                    case false:
                        StartCoroutine(OutDelay("four_isIn"));
                        break;
                }
                break;
        }
    }

    public void DialogueFinished()
    {
        animator.SetBool("box_isIn", false);
        animator.SetBool("one_isIn", false);
        animator.SetBool("two_isIn", false);
        animator.SetBool("three_isIn", false);
        animator.SetBool("four_isIn", false);
    }

    IEnumerator OutDelay(string imageNumber)
    {
        yield return new WaitForSeconds(.5f);
        animator.SetBool(imageNumber, false);
    }
}