using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private CharacterAnimations charAnim;

    private float currentAttackTime;
    private float defaultAttackTime=2.05f;

    enum Attacks
    {
        Punches =1,
        Kick
    }
    // Start is called before the first frame update
    void Awake()
    {
        charAnim = GetComponentInChildren<CharacterAnimations>();
    }


    public void EnemyAttacks()
    {
        int selectedAttack = Random.Range(1, 3);
        Attacks attack = (Attacks)selectedAttack;

        currentAttackTime += Time.deltaTime;
        if (currentAttackTime > defaultAttackTime)
        {
            if (attack == Attacks.Punches)
                charAnim.Punches();
            else if (attack == Attacks.Kick)
                charAnim.Kick();
            currentAttackTime = 0;
        }
    }

}
