using System;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public Animator characterAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterAnimator =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxis("Horizontal");

        characterAnimator.SetFloat("Speed", Math.Abs(speed));
        if (Input.GetButtonDown("Jump"))
        {
            characterAnimator.SetBool("isJumping", true);
        }
    }

    public void OnLanding()
    {
        characterAnimator.SetBool("isJumping", false);
    }
}
