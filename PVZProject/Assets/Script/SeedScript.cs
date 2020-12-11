using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SeedScript : MonoBehaviour
{

    //Scipt ini adalah untuk mengatur kartu tanaman;

    public GameObject prefabPlant;
    private bool canPlant = true;
    public AudioSource[] sounds;


    void OnMouseDown()
    {
        if (canPlant && !GameManager.shovelEnabled && GameManager.currentPlant == null && GameManager.cash >= prefabPlant.GetComponent<Properties> ().price)
        {
            // untuk menaruh object
            sounds[0].Play();
            GameManager.currentSeed = gameObject;
            GameManager.currentPlant = prefabPlant;

        }else if (!canPlant || GameManager.cash < prefabPlant.GetComponent<Properties> ().price)
        {
            sounds[1].Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!canPlant || GameManager.cash < prefabPlant.GetComponent<Properties>().price)
        {
            GetComponent<SpriteRenderer>().material.color = Color.grey;
        }
        else
        {
            GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }

    public void StartRecharge()
    {
        canPlant = false;
        GameManager.currentSeed = null;
        StartCoroutine("WaitTime");
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(prefabPlant.GetComponent<Properties>().timeRecharge);
        canPlant = true;
    }


}
