using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaScript : MonoBehaviour
{

    private Image content;

    private float currentFill;

    private float currentEnergy;

    
    public float MyMaxEnergy
    {
        get;

        set;
    }

    public float MyCurrentValue {

        get
        {
            return currentEnergy;
        }

        set
        {
            if (value > MyMaxEnergy)
            {
                currentEnergy = MyMaxEnergy;
            }
            else if (value < 0)
            {
                currentEnergy = 0;
            }
            else
            {
                currentEnergy = value;
            }

            currentFill = currentEnergy / MyMaxEnergy;

        }
    }

    void Start()
    {
        content = GetComponent<Image>();
    }

    void Update()
    {
        content.fillAmount = currentFill;
    }

    public void Initialized(float currentEnergy, float maxEnergy)
    {
        MyCurrentValue = currentEnergy;
        MyMaxEnergy = maxEnergy;
    }

}
