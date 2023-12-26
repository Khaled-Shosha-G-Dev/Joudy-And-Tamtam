using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player attack animation
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

    private CharacterAnimations charAnim;
    private void Awake()
    {
        charAnim = GetComponentInChildren<CharacterAnimations>();
    }

    private void Update()
    {
        ComboPunchs();
        ComboKicks();
    }

    //display diffrent punchs randomly
    private void ComboPunchs()
    {
        int randomPunch = Random.Range(5,9);
        if (Input.GetKeyDown(KeyCode.F))
        {
            ComboAttack selectedAttack = (ComboAttack)randomPunch;
            if (selectedAttack == ComboAttack.Punch1)
                charAnim.Punch_1();
            else if (selectedAttack == ComboAttack.Punch2)
                charAnim.Punch_2();
            else if (selectedAttack == ComboAttack.Punch3)
                charAnim.Punch_3();
            else if (selectedAttack == ComboAttack.Punch4)
                charAnim.Punch_4();
        }
    }

    //display diffrent Kicks Randomly
    private void ComboKicks()
    {

        int randomKick = Random.Range(1, 5);
        if (Input.GetKeyDown(KeyCode.G))
        {
            ComboAttack selectedAttack = (ComboAttack)randomKick;
            if (selectedAttack == ComboAttack.Kick1)
                charAnim.Kick_1();
            else if (selectedAttack == ComboAttack.Kick2)
                charAnim.Kick_2();
            else if (selectedAttack == ComboAttack.Kick3)
                charAnim.Kick_3();
            else if (selectedAttack == ComboAttack.Kick4)
                charAnim.Kick_4();
        }

    }

    //Enable funtion to attack points
    //Desable Function to
}
