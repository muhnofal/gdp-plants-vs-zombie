using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class grassInstantiate : MonoBehaviour
{

    //Script ini untuk melooping Object grass sebanyak 45 kali

    public GameObject prefabGrass;
    private GameObject grass;
    private float currentX = -5.498f, currentY = 2.725f, distanceX, distanceY;
    private bool newLine = true;

    // Start is called before the first frame update
    void Start()
    {
        distanceX = prefabGrass.GetComponent<SpriteRenderer>().bounds.size.x;
        distanceY = prefabGrass.GetComponent<SpriteRenderer>().bounds.size.y;

        for(int i = 0; i < 45; i++)
        {

            if(i % 9 == 0 && i != 0)
            {
                newLine = true;
                currentY = grass.transform.position.y - distanceY;
            }

            if (newLine)
            {
                newLine = false;
                grass = Instantiate(prefabGrass, new Vector2(-5.498f, currentY), Quaternion.identity) as GameObject;
            }
            else
            {
                grass = Instantiate(prefabGrass, new Vector2(currentX, currentY), Quaternion.identity) as GameObject;
            }

            currentX = grass.transform.position.x + distanceX;
            grass.transform.SetParent(transform);
        }
    }
}
