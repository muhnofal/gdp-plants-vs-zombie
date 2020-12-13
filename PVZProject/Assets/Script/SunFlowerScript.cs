using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerScript : MonoBehaviour
{

    //Script untuk menangani Karakter Sun Flower

    public GameObject prefabSun;
    public EnergyScript energyBar;
    public int Energycooldown = 0;
    public int timeRecharge;
    public int speed = 0;
    [SerializeField]
    private int maxEnergy = 0;
    [SerializeField]
    private int currentEnergy = 0;

    public WaitForSeconds regenSpeed = new WaitForSeconds(1f);


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateSun", 5, speed);
        energyBar.setMaxEnergy(maxEnergy);
        energyBar.setEnergy(currentEnergy);
        StartCoroutine(regenFirst());
    }

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
        
        if (Input.GetMouseButtonDown(0))
        {
            UseStamina(maxEnergy);
        }

    }

    void InstantiateSun()
    {
       var temp = Instantiate(prefabSun, transform.position, Quaternion.identity) as GameObject;
        temp.GetComponent<SunScript>().newInstance = true;
    }

    // ketika memencet skill tanaman
    public void UseStamina(int amount)
    {
        if (currentEnergy - amount >= 0)
        {
            currentEnergy -= amount;
            energyBar.setEnergy(currentEnergy);
            StartCoroutine(regenEnergy());
        }
        else
        {

        }
    }

    //Ketika skill active
    void skillActive()
    {
        speed -= 18;
        InvokeRepeating("InstantiateSun", 3, speed);
    }

    //Ketika skill tidak active
    void skillDeactive()
    {
        speed += 18;
        InvokeRepeating("InstantiateSun", 0, speed);
    }

    // ini untuk ketika player memencet skill, dah akhirnya regen setelah 10 detik
    private IEnumerator regenEnergy()
    {
        skillActive();
        yield return new WaitForSeconds(Energycooldown);
        CancelInvoke();
        skillDeactive();
        while (currentEnergy < maxEnergy)
        {
            currentEnergy += maxEnergy / maxEnergy;
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
            currentEnergy += maxEnergy / maxEnergy;
            energyBar.setEnergy(currentEnergy);
            yield return regenSpeed;
        }
    }

}
