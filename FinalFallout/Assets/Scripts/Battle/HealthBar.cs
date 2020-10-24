using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;


    public void SetMaxHealth(int health)
    {
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = (float)health;
        slider.value = (float)health;
    }

    public void UpdateHealth(int health)
    {
        slider.value = (float)health;
    }
}
