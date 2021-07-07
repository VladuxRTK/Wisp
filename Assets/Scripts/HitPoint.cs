using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // GetComponent<Collider2D>().enabled = false;
            //  hasLanded = true;
            //rb.isKinematic = true;
            Transform playerTransform = collision.gameObject.transform;

            Destroy(collision.gameObject);
            audioManager.PlaySound("fallingPlatformSound");
            Instantiate(collision.gameObject.GetComponent<PlayerController>().deathVFX, playerTransform.position, Quaternion.identity);
            //collision.gameObject.GetComponent<PlayerController>().Die(true);
            // GetComponent<Collider2D>().enabled = true;
        }
        
        
    }
}
