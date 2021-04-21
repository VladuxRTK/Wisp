using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePoint;
    public Animator barrel;

    private Transform player;
    private Quaternion rotation;
    private AudioManager audioManager;

    private bool canShoot;
    public float timeBtwShots;
    private float startTimeBtwShots;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        startTimeBtwShots = timeBtwShots;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position,player.position)<10f)
        {
            RotateToPlayer();
            if (IsSeen() && timeBtwShots <= 0)
            {
                barrel.SetTrigger("Barrel_Shoot");

                StartCoroutine(Shooting());
                if(canShoot)
                {
                    Shoot();
                }
                timeBtwShots = startTimeBtwShots;

            }
          
            else if((IsSeen() || !IsSeen()) && timeBtwShots>0)
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    private void Shoot()
    {
       
        
            Instantiate(bullet, firePoint.position, this.transform.rotation);
            audioManager.PlaySound("laserSound");
        canShoot = false;
        
        
    }

    

    private void RotateToPlayer()
    {
        Vector2 direction = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
    }

    private bool IsSeen()
    {
        Vector2 direction = player.position - this.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction.normalized, direction.magnitude);
        if(hit)
        {
            if(hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    bool AnimatorIsPlaying()
    {
        return barrel.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }

    private IEnumerator Shooting()
    {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
        
       
    }
}
