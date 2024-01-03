using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation
{
    public const string MOVEMENT = "Walk";
    public const string IDEL_ANIMATION = "Idel";
    public const string HIT_TRIGGER = "Hit";
    public const string DEATH_TRIGGER = "Death";
    //Player
    public const string PUNCH_1_TRIGGER = "Punch1";
    public const string PUNCH_2_TRIGGER = "Punch2";
    public const string PUNCH_3_TRIGGER = "Punch3";
    public const string PUNCH_4_TRIGGER = "Punch4";

    public const string KICK_1_TRIGGER = "Kick1";
    public const string KICK_2_TRIGGER = "Kick2";
    public const string KICK_3_TRIGGER = "Kick3";
    public const string KICK_4_TRIGGER = "Kick4";

    public const string KNOCK_DOWN_TRIGGER = "KnockDown";
    public const string STAND_UP_TRIGGER = "StandUp";

    //Enemy
    public const string PUNCHES = "Punch";
    public const string KICK = "Kick";
}

public class Axis
{
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
}

public class Tags
{
    public const string PLAYER_TAG = "Player";
    public const string GROUND_TAG = "Ground";
    public const string ENEMY_TAG = "Enemy";

    public const string GROUND_ARM_TAG = "LeftArm";
    public const string LEFT_LEG_TAG = "LeftLeg";
    public const string UNTAGGED_TAG = "Untagged";
    public const string MAIN_CAMERA_TAG = "MainCamera";
    public const string HEALTH_UI = "HealthUI";

    public const string LEG_ATTACK = "LegAttack";
    public const string Hand_ATTACK = "HandAttack";
    public const string Enemy_LEG_ATTACK = "E_LegAttack";
    public const string Enemy_Hand_ATTACK = "E_HandAttack";
}