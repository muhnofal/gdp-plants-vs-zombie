using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    public GameObject prefabPlant;
    public EnergyScript energyBar;

    public int life, price, timeRecharge;

    public int maxEnergy = 100;
    private int currentEnergy = 0;
    
    public WaitForSeconds regenSpeed = new WaitForSeconds(1f);

    

    void Start()
    {
        energyBar.setMaxEnergy(maxEnergy);
        energyBar.setEnergy(currentEnergy);
        StartCoroutine(regenFirst());

    }

    // Update is called once per frame
    void Update()
    {

        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        else if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }

    }

    // Pencet Tanaman
    private void OnMouseDown()
    {
        UseStamina(100);
    }

    void checkDeath()
    {
        if (life < 0)
        {
            Destroy(gameObject);
        }
    }

    void takeDamage(float energy)
    {
        //currentEnergy -= energy;
        //energyBar.setEnergy(currentEnergy);
    }

    // ketika memencet skill tanaman
    public void UseStamina(int amount)
    {
        if(currentEnergy - amount >= 0 )
        {
            currentEnergy -= amount;
            energyBar.setEnergy(currentEnergy);

            StartCoroutine(regenEnergy());
        }
        else
        {

        }
    }

    // ini untuk ketika player memencet skill, dah akhirnya regen setelah 10 detik
    private IEnumerator regenEnergy()
    {
        yield return new WaitForSeconds(10);

        while(currentEnergy < maxEnergy)
        {
            currentEnergy += maxEnergy / 100;
            energyBar.setEnergy(currentEnergy);
            yield return regenSpeed;

        }
    }

    // Ini untuk regen pas pertama ngedeploy tanaman pertama kali
    private IEnumerator regenFirst()
    {
        yield return new WaitForSeconds(0);

        while (currentEnergy < maxEnergy)
        {
            currentEnergy += maxEnergy / 100;
            energyBar.setEnergy(currentEnergy);
            yield return regenSpeed;
        }
    }

}
