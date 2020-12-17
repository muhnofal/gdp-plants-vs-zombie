using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{

    //Script Properties adalah hal - hal yang menyangkut tentang karakter secara umum, seperti harga, dan life;

    public GameObject prefabPlant;
    public int life, price;
    public int timeRecharge;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkDeath();

    }

    void checkDeath()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }



}
