using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private staminaScript energy;

    [SerializeField]
    private float energyValue = 100;
    
    [SerializeField]
    private float maxEnergy = 100;
     
    // Start is called before the first frame update
    void Start()
    {
        energy.Initialized(energyValue, maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            energy.MyCurrentValue -= 10;
        }

    }

}