using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterScript : MonoBehaviour
{

    public GameObject prefabPea;
    private float distance;

    //Script untuk menangani Karakter Pea Shooter
    public EnergyScript energyBar;
    public int Energycooldown = 0;
    public int timeRecharge;
    public float speedPea = 0;
    [SerializeField]
    private int maxEnergy = 0;
    [SerializeField]
    private int currentEnergy = 0;
    private Animator anim;

    public WaitForSeconds regenSpeed = new WaitForSeconds(1f);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0, speedPea);
        distance = 4.09f - transform.position.x;
        energyBar.setMaxEnergy(maxEnergy);
        energyBar.setEnergy(currentEnergy);
        StartCoroutine(regenFirst());
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (currentEnergy >= maxEnergy)
        {
            currentEnergy = maxEnergy;

        }
        else if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }

    }

    private void OnMouseDown()
    {

        if (Input.GetMouseButton(0))
        {
            UseStamina(maxEnergy);
        }

    }

    // Update is called once per frame
    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, distance, LayerMask.GetMask("Zombie"));
        if(hit.collider != null)
        {
            Instantiate(prefabPea, transform.position, Quaternion.identity);
        }
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
        speedPea = 1f;
        InvokeRepeating("Shoot", 0, speedPea); //1.5
    }

    //Ketika skill tidak active
    void skillDeactive()
    {
        speedPea = 1.5f;
        InvokeRepeating("Shoot", 0, speedPea);
    }

    // ini untuk ketika player memencet skill, dah akhirnya regen setelah 10 detik
    private IEnumerator regenEnergy()
    {
        skillActive();
        anim.SetBool("peaSkillActive", true);
        yield return new WaitForSeconds(Energycooldown);
        anim.SetBool("peaSkillActive", false);
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
