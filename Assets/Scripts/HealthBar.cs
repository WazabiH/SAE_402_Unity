using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; 

    public Gradient gradient; // permet de changer la couleur de la barre de vie
    public Image fill; // permet de changer la couleur de la barre de vie
    public void SetMathHealth(int health) // permet que la barre de vie soit à 100 pourent des le debut
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f); // permet de changer la couleur de la barre de vie
    }
    public void SetHealth(int health) // indique à la barre de vie le nbr de point vie à afficher 
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue); // permet de changer la couleur de la barre de vie
    }
}
