using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private const String IS_WALKING = "IsWalking";

    private Animator animator;

    [SerializeField]
    private PlayerMovement player;
    
    void Awake(){
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(IS_WALKING, player.IsPlayerWalking());
    }
}
