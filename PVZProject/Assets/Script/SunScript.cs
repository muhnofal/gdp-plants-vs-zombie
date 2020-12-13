using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{

    public float vel;
    public AudioClip clip;
    [HideInInspector]
    public bool newInstance = false;

    private Rigidbody2D rb;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //tumpang tindih
        if (col.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            OnMouseDown();
    }

    void FixedUpdate()
    {
        if (!newInstance)
            rb.velocity = new Vector2(0, -vel * Time.deltaTime);
    }

    //Ketika Menekan matahari
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.cash += 25;
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            Destroy(gameObject);

        }    
    }

}
