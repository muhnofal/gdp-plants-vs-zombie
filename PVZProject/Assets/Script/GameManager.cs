using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Script Untuk Mengatur Mekanik Game;
    //Disini baru ada cash, dan shove(belum bisa dipake)
    public static int cash;
    public static bool shovelEnabled;
    public GameObject prefabSun;
    public Transform pointSun;
    public static GameObject currentPlant, currentSeed;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateSun", 10, 20);
        cash = 50;
        shovelEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cash >= 9999)
        {
            cash = 9999;
        }
    }

    void InstantiateSun()
    {
        Instantiate(prefabSun, pointSun.position, Quaternion.identity);
    }

}
