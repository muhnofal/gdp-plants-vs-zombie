using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerScript : MonoBehaviour
{

    //Script untuk menangani Karakter Sun Flower

    public GameObject prefabSun;
    public EnergyScript energyBar;
    public int Energycooldown = 0;
    public int speed = 0;
    [SerializeField]
    private int maxEnergy = 0;
    [SerializeField]
    private int currentEnergy = 0;
    private Collider2D col;
    private Animator anim;
    private AudioSource sound;

    public WaitForSeconds regenSpeed = new WaitForSeconds(1f);


    // Start is called before the first frame update
    void Start()
    {
        energyBar.setMaxEnergy(maxEnergy);
        energyBar.setEnergy(currentEnergy);
        StartCoroutine(regenFirst());
        InvokeRepeating("InstantiateSun", 5, speed);
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (currentEnergy >= maxEnergy)
        {
            currentEnergy = maxEnergy;
            if (col.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                OnMouseDown();
        }
        else if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }

    }

    //Pencet Tanaman
    private void OnMouseDown()
    {

        if (Input.GetMouseButton(0))
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
        speed = 3;
        InvokeRepeating("InstantiateSun", 3, speed);
    }

    //Ketika skill tidak active
    void skillDeactive()
    {
        speed += 20;
        InvokeRepeating("InstantiateSun", 0, speed);
    }

    // ini untuk ketika player memencet skill, dah akhirnya regen setelah 10 detik
    private IEnumerator regenEnergy()
    {
        if (!sound.isPlaying)
            sound.Play();
        skillActive();
        anim.SetBool("SkillActive", true);
        yield return new WaitForSecondsRealtime(5);
        anim.SetBool("SkillActive", false);
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
        yield return new WaitForSecondsRealtime(0);

        while (currentEnergy < maxEnergy)
        {
            currentEnergy += maxEnergy / maxEnergy;
            energyBar.setEnergy(currentEnergy);
            yield return regenSpeed;
        }
    }

}
