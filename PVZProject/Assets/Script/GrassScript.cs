using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScript : MonoBehaviour
{

    //Script ini untuk menangani object grass.
    //Untuk saat ini kita sudah bisa menaruh tanaman di grass

    private bool isEmpty;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, LayerMask.GetMask("Plants"));
        isEmpty = hit.collider == null;
    }

    void OnMouseDown()
    {
        if(isEmpty && GameManager.currentPlant != null)
        {
            Instantiate(GameManager.currentPlant, transform.position, Quaternion.identity);
            GameManager.cash -= GameManager.currentPlant.GetComponent<Properties>().price;
            GameManager.currentPlant = null;
            GameManager.currentSeed.GetComponent<SeedScript>().StartRecharge();
        }    
    }
}
