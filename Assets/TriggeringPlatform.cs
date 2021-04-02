using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringPlatform : MonoBehaviour
{
    public Transform targetPoint;

    private Vector2 initPoint;
    private Rigidbody2D rb;
    private bool shouldFall;
    public bool hasFallen;
    public bool ableToFall;
    public float speed;
    public bool hasLanded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initPoint = this.transform.position;
        shouldFall = true;
        hasFallen = false;
        ableToFall = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, targetPoint.position, 20f);
        /*if (hit)
        {
            if (hit.collider.CompareTag("Player") && shouldFall)
            {
                shouldFall = false;
                StartCoroutine(Fall());

            }
            if (has)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, initPoint, speed * Time.deltaTime);
            }
            if (this.transform.position.x == initPoint.x && initPoint.y == this.transform.position.y)
            {
                shouldFall = true;
            }
        }*/
        if(hasFallen)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, initPoint, speed * Time.deltaTime);
        }
        if (this.transform.position.x == initPoint.x && initPoint.y == this.transform.position.y)
        {
            ableToFall = true;
            hasFallen = false;
            
        }
        else
        {
            ableToFall = false;
            
        }
        if(hasLanded)
        {
            StartCoroutine(GoBack());
        }
       
    }

    private IEnumerator Fall()
    {
        rb.isKinematic = false;
        yield return new WaitForSeconds(0.3f);
        rb.isKinematic = true;

        // shouldFall = true;


    }

    public void SetRb(bool value)
    {
        rb.isKinematic = value;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            hasLanded = true;
            rb.isKinematic = true;
          
            
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            hasLanded = true;
            rb.isKinematic = true;
        }
    }

    // Go back to initial Point after some time
    private IEnumerator GoBack()
    {
        yield return new WaitForSeconds(1f);
        hasFallen = true;
        hasLanded = false;
    }

}