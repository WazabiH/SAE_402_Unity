using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; 

    public void SetMathHealth(int health) // permet que la barre de vie soit à 100 pourent des le debut
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health) // indique à la barre de vie le nbr de point vie à afficher 
    {
        slider.value = health;
    }
}
