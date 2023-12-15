using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboAttack
{
    Kick1=1,
    Kick2,
}

public class PlayerAttack : MonoBehaviour
{
    private Animator playerAnim;

    private void Awake()
    {
        playerAnim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        ComboPunchs();
        ComboKicks();
    }

    private void ComboPunchs()
    {
        if (Input.GetKeyDown(KeyCode.F))
            playerAnim.SetTrigger("Punch1");
    }
    private void ComboKicks()
    {

        int randomKick = Random.Range(1, 3);
        if (Input.GetKeyDown(KeyCode.G))
        {
            ComboAttack selectedAttack = (ComboAttack)randomKick;
            if (selectedAttack == ComboAttack.Kick1)
                playerAnim.SetTrigger("Kick1");
            else if (selectedAttack == ComboAttack.Kick2)
                playerAnim.SetTrigger("Kick2");
        }

    }
}
