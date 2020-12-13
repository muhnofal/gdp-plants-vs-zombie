using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{

    //Script untuk mengontrol zombie

    public float life, vel;
    private bool canWalk, canEat;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        canEat = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckPlant();
        CheckDeath();
    }

    void FixedUpdate()
    {

        rb.velocity = canWalk ? new Vector2(-vel * Time.deltaTime, 0) : Vector2.zero;
    }

    void CheckDeath()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    void CheckPlant()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 0.3f, LayerMask.GetMask("Plants"));
        if(hit.collider != null)
        {
            anim.SetBool("Makan", true);
            canWalk = false;
            if (canEat)
                StartCoroutine(Eating(hit.collider));

            if (!sound.isPlaying)
                sound.Play();
        }
        else
        {
            sound.Stop();
            StopCoroutine("Eating");
            canWalk = canEat = true;
            anim.SetBool("Makan", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Reset")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Eating(Collider2D col)
    {
        canEat = false;
        yield return new WaitForSeconds(2);
        canEat = true;
        if(col != null)
        col.gameObject.GetComponent<Properties>().life--;
    }

}
