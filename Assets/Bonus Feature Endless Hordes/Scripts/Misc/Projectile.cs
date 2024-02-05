using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 200f;
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }
}
