using System;
using TarodevController;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator characterAnimator = null;
    private PlayerController _controller = null;

    void Start()
    {
        characterAnimator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        characterAnimator.SetFloat("Speed", Math.Abs(speed));
        characterAnimator.SetBool("isJumping", !_controller.IsGrounded());

        //if (Input.GetButtonDown("Jump"))
        //{
        //    characterAnimator.SetBool("isJumping", true);
        //}
    }

    public void OnLanding()
    {
        characterAnimator.SetBool("isJumping", false);
    }
}
