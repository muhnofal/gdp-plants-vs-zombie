using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int cash;
    public static bool shovelEnabled;

    public static GameObject currentPlant, currentSeed;

    // Start is called before the first frame update
    void Start()
    {
        cash = 999;
        shovelEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
