using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchronisedPlatform : MonoBehaviour
{

    public List<GameObject> platforms;
    public List<Transform> initialPoints;
    public float speed;
    public bool fallEven;

    public float fallEvenTimer;
    private float startFallEvenTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        fallEven = true;
        startFallEvenTimer = fallEvenTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(FallPlatforms());

        if(fallEvenTimer<=0)
        {
            if(fallEven)
            {
              
                    
                        platforms[0].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                        platforms[2].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                // platforms[i].gameObject.transform.position = Vector2.MoveTowards(platforms[i].gameObject.transform.position, initialPoints[i].position, speed * Time.deltaTime);



                        platforms[1].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                        platforms[3].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                        platforms[1].gameObject.transform.position = Vector2.MoveTowards(platforms[1].gameObject.transform.position, initialPoints[1].position, speed * Time.deltaTime);
                        platforms[3].gameObject.transform.position = Vector2.MoveTowards(platforms[3].gameObject.transform.position, initialPoints[1].position, speed * Time.deltaTime);
                //fallEven = false;

            }
            if(!fallEven)
            {


                platforms[1].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                platforms[3].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                // platforms[i].gameObject.transform.position = Vector2.MoveTowards(platforms[i].gameObject.transform.position, initialPoints[i].position, speed * Time.deltaTime);



                platforms[0].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                platforms[2].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                platforms[0].gameObject.transform.position = Vector2.MoveTowards(platforms[0].gameObject.transform.position, initialPoints[0].position, speed * Time.deltaTime);
                platforms[2].gameObject.transform.position = Vector2.MoveTowards(platforms[2].gameObject.transform.position, initialPoints[2].position, speed * Time.deltaTime);
               // fallEven = true;


            }
            fallEvenTimer = startFallEvenTimer;
           
        }
        else
        {
            fallEvenTimer -= Time.deltaTime;
            fallEven = !fallEven;
        }
    }

    private IEnumerator FallPlatforms()
    {
        /*if(fallEven)
        {
            for(int i = 0;i<platforms.Count;i++)
            {
                if(i%2==0)
                {
                    platforms[i].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                 
                   
                }
            }
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < platforms.Count; i++)
            {
                platforms[i].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                platforms[i].gameObject.transform.position = Vector2.MoveTowards(platforms[i].gameObject.transform.position, initialPoints[i].position, speed * Time.deltaTime);
                fallEven = !fallEven;
            }
           
        }
        if(!fallEven)
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (i % 2 == 1)
                {
                    platforms[i].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    

                }
            }
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < platforms.Count; i++)
            {
                platforms[i].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                platforms[i].gameObject.transform.position = Vector2.MoveTowards(platforms[i].gameObject.transform.position, initialPoints[i].position, speed * Time.deltaTime);
                fallEven = !fallEven;
            }
        }*/

        platforms[0].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        platforms[1].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        yield return new WaitForSeconds(2f);
        platforms[0].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        platforms[1].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        platforms[0].gameObject.transform.position = Vector2.MoveTowards(platforms[0].gameObject.transform.position, initialPoints[0].position, speed * Time.deltaTime);
        platforms[1].gameObject.transform.position = Vector2.MoveTowards(platforms[1].gameObject.transform.position, initialPoints[1].position, speed * Time.deltaTime);
        platforms[2].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        platforms[3].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        yield return new WaitForSeconds(2f);
        platforms[2].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        platforms[3].gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        platforms[2].gameObject.transform.position = Vector2.MoveTowards(platforms[2].gameObject.transform.position, initialPoints[2].position, speed * Time.deltaTime);
        platforms[3].gameObject.transform.position = Vector2.MoveTowards(platforms[3].gameObject.transform.position, initialPoints[3].position, speed * Time.deltaTime);

    }
}
