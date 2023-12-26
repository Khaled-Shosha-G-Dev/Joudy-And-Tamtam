using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider activeHealthbar;

    private void Update()
    {
        LookAtCamera();
    }
    public void SetHealthbar(int health)
    {
        activeHealthbar.value = health;
    }

    public void SetMAXhealthbar(int maxhealth)
    {
        activeHealthbar.maxValue = maxhealth;
    }

    private void LookAtCamera()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
