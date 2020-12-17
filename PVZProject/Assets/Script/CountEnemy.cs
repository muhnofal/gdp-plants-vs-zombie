using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountEnemy : MonoBehaviour
{

    GameObject[] enemies;
    public Text enemyCountText;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Zombie");
        enemyCountText.text = "Enemies: " + enemies.Length.ToString();

        if(enemies.Length <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
