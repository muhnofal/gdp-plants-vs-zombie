using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{

    public Slider energyBar;


    public void setMaxEnergy(int energy)
    {
        energyBar.maxValue = energy;
        energyBar.value = energy;
    }

    public void setEnergy(int energy)
    {
        energyBar.value = energy;
    }

}
