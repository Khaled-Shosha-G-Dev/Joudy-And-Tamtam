using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboAttack
{
    Kick1=1,
    Kick2,
    Kick3,
    Kick4,
    Punch1,
    Punch2,
    Punch3,
    Punch4,

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
        int randomPunch = Random.Range(5,9);
        if (Input.GetKeyDown(KeyCode.F))
        {
            ComboAttack selectedAttack = (ComboAttack)randomPunch;
            if (selectedAttack == ComboAttack.Punch1)
                playerAnim.SetTrigger("Punch1");
            else if (selectedAttack == ComboAttack.Punch2)
                playerAnim.SetTrigger("Punch2");
            else if (selectedAttack == ComboAttack.Punch3)
                playerAnim.SetTrigger("Punch3");
            else if (selectedAttack == ComboAttack.Punch4)
                playerAnim.SetTrigger("Punch4");
        }
    }
    private void ComboKicks()
    {

        int randomKick = Random.Range(1, 5);
        if (Input.GetKeyDown(KeyCode.G))
        {
            ComboAttack selectedAttack = (ComboAttack)randomKick;
            if (selectedAttack == ComboAttack.Kick1)
                playerAnim.SetTrigger("Kick1");
            else if (selectedAttack == ComboAttack.Kick2)
                playerAnim.SetTrigger("Kick2");
            else if (selectedAttack == ComboAttack.Kick3)
                playerAnim.SetTrigger("Kick3");
            else if (selectedAttack == ComboAttack.Kick4)
                playerAnim.SetTrigger("Kick4");
        }

    }
}
