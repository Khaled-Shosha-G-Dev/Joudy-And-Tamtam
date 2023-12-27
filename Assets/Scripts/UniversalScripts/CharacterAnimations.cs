using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;
    
    //run on start
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //Idel Animation function
    public void PlayIdelAnimation()
    {
        anim.Play(Animation.IDEL_ANIMATION);
    }
    //walk animation functoin
    public void Walk(bool move)
    {
        anim.SetBool(Animation.MOVEMENT, move);
    }

    //Punchs Functions
    public void Punch_1()
    {
        anim.SetTrigger(Animation.PUNCH_1_TRIGGER);
    }
    public void Punch_2()
    {
        anim.SetTrigger(Animation.PUNCH_2_TRIGGER);
    }
    public void Punch_3()
    {
        anim.SetTrigger(Animation.PUNCH_3_TRIGGER);
    }
    public void Punch_4()
    {
        anim.SetTrigger(Animation.PUNCH_4_TRIGGER);
    }

    //Kicks Functions
    public void Kick_1()
    {
        anim.SetTrigger(Animation.KICK_1_TRIGGER);
    }
    public void Kick_2()
    {
        anim.SetTrigger(Animation.KICK_2_TRIGGER);
    }
    public void Kick_3()
    {
        anim.SetTrigger(Animation.KICK_3_TRIGGER);
    }
    public void Kick_4()
    {
        anim.SetTrigger(Animation.KICK_4_TRIGGER);
    }

    //hit function
    public void Hit()
    {
        anim.SetTrigger(Animation.HIT_TRIGGER);
    }
    //Death function
    public void Death()
    {
        anim.SetTrigger(Animation.DEATH_TRIGGER);
    }
    // Enemy Punches
    public void Punches()
    {
        anim.SetTrigger(Animation.PUNCHES);
    }
    public void Kick() 
    {
        anim.SetTrigger(Animation.KICK);
    }
}
