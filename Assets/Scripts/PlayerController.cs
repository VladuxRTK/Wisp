using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 targetPos;
    private Rigidbody2D rb;
    private bool isMoving;
    private Vector2 direction;
    public float changeDirCooldown;
    public float initialSpeed;
    public GameObject deathVFX;

    
    public bool hasAddedPos;

    //public Ghost ghost;

    public List<Color> healthColors;

    public float timeHit;

    public static int numberOfHits;

    public GhostEntity ghost;
    public GhostReplayer ghost2;

    // public List<Transform> positions;

    private Vector2 movement;

    private GameManager gm;
    private AudioManager audioManager;
    private float changeCool;
    private bool canChangeDir;
    private bool isPaused;
    public bool laserHit;
    private Material material;
    public bool isRunning;
    
    private int numberOfTimePaused;
    private IEnumerator blink;
    private int numberOfLastHit;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // material = GetComponent<Renderer>().material;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        sr = GetComponent<SpriteRenderer>();
        isRunning = false;
        initialSpeed = moveSpeed;
        changeCool = changeDirCooldown;
        canChangeDir = true;
        isPaused = false;
        blink = Blink();
        numberOfHits = 0;
        numberOfLastHit = 0;
        laserHit = false;
    }


    void Update()
    {
        //Debug.Log(numberOfHits);
        // Debug.Log(positions);

        //DieLaser();
        if (numberOfHits != 0 && timeHit <=0)
        {
            timeHit = 6f;

            numberOfHits = 0;
            //numberOfInitialHits = 0;
            numberOfLastHit = 0;
            sr.material.color = Color.white;
        }
        if (timeHit >= 0 && numberOfHits != 0)
        {

            if (numberOfLastHit < numberOfHits)
            {
                timeHit = 6f;
                numberOfLastHit = numberOfHits;
            }
            else { timeHit -= Time.deltaTime;
                if (timeHit <= 2f)
                {
                    StartCoroutine(Blink());
                }
               /* if(timeHit>=2f && isRunning)
                {
                    StopCoroutine(blink);
                }*/
            }
           
          
        }
        
       
        if (numberOfHits == 1 && numberOfLastHit==0)
        {
            // this.material.color =(new Color(168, 71, 71));
            sr.material.color = new Color(0.8207547f, 0.360048f, 0.360048f);
            numberOfLastHit = numberOfHits;
        }
        if (numberOfHits == 2 && numberOfLastHit==0)
        {
            //   this.material.color = new Color(183, 77, 77);
            //sr.material.color = new Color(183, 77, 77);
            //   Color color = new Color(183, 77, 77);

            sr.material.color = new Color(0.9150943f, 0.1769758f, 0.1769758f);
            numberOfLastHit = numberOfHits;
        }
        if (numberOfHits == 3 && numberOfLastHit ==0)
        {
            //  this.material.color = new Color(214, 60, 60);
            sr.material.color = Color.red;
            numberOfLastHit = numberOfHits;
        }
        if (numberOfHits == 1)
        {
            // this.material.color =(new Color(168, 71, 71));
            sr.material.color = new Color(0.8207547f, 0.360048f, 0.360048f);
            
        }
        if (numberOfHits == 2)
        {
            //   this.material.color = new Color(183, 77, 77);
            //sr.material.color = new Color(183, 77, 77);
            //   Color color = new Color(183, 77, 77);

            sr.material.color = new Color(0.9150943f, 0.1769758f, 0.1769758f);
        }
        if (numberOfHits == 3 )
        {
            //  this.material.color = new Color(214, 60, 60);
            sr.material.color = Color.red;

        }
        Die();

      
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (changeDirCooldown <= 0)
        {
            canChangeDir = true;


        }

        else
        {
            changeDirCooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !(numberOfTimePaused == gm.pausesPerLevel))
        {
            isPaused = !isPaused;
            numberOfTimePaused += 1;
        }

        // rb.isKinematic = true; 
        Pause();
        if(laserHit)
        {
           // Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            //laserHit = !laserHit;
        }

    }
    private void FixedUpdate()
    {


        Move();



    }

    private void SetTargetPosition()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        direction = targetPos - this.transform.position;
        direction = direction.normalized;

        isMoving = true;
    }
    private void Move()
    {
        rb.velocity = movement * moveSpeed;



        //positions.Add(this.transform);
        //  transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
        canChangeDir = false;

        /*  if (Mathf.Abs(this.transform.position.x - this.targetPos.x) < float.Epsilon && Mathf.Abs(this.transform.position.y - this.targetPos.y) < float.Epsilon)
          {
              Debug.Log("Aici");
              isMoving = false;
              // rb.velocity = Vector2.zero;

          }*/


    }

    private void StopMoving()
    {
        if (Mathf.Abs(this.transform.position.x - this.targetPos.x) < float.Epsilon && Mathf.Abs(this.transform.position.y - this.targetPos.y) < float.Epsilon)
        {
            Debug.Log("Aici");
            isMoving = false;
            // rb.velocity = Vector2.zero;

        }
    }

    private void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void SetTargetPosition(Vector3 targetPos)
    {
        this.targetPos = targetPos;
    }

    //Make the player blink when close to resetting number of hits
    private IEnumerator Blink()
    {
        isRunning = true;
        Color currentColor;
        
        currentColor = sr.material.color;
        /*while(timeHit!=0)
        {
            yield return new WaitForSeconds(0.2f);
            sr.material.color = currentColor;
            yield return new WaitForSeconds(0.2f);
            sr.material.color = Color.white;
        }*/
        sr.material.color = Color.white;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = currentColor;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = Color.white;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = currentColor;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = Color.white;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = currentColor;
        yield return new WaitForSeconds(0.3f);
        sr.material.color = Color.white;
        /*if (!laserHit)
        {
            
            int counter = 0;
            while (counter < 6)
            {
                Debug.Log("Here");

                sr.material.color = Color.white;
                yield return new WaitForSeconds(0.3f);
                sr.material.color = currentColor;
                counter++;
            }
        }
        if(laserHit)
        {
            yield break;
        }*/
        isRunning = false;
      /*  yield return new WaitForSeconds(0.2f);
        sr.material.color = currentColor;
        yield return new WaitForSeconds(0.2f);
        sr.material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sr.material.color = currentColor;
        yield return new WaitForSeconds(0.2f);
        sr.material.color = Color.white;*/


    }

    public void Die()
    {
        if (numberOfHits == 4)
        {
            gm.numberOfTriesPerLevel[SceneManager.GetActiveScene().buildIndex]++;
            gm.isPlayerDead = true;
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            //ghost.canAdd = true;
            //  //ghost.AddPoints(positions);
            // positions = new List<Transform>();
          //  ghost.isRecording = false;
            
            audioManager.PlaySound("laserDeathSound");
            numberOfHits = 0;
          
            //GetComponent<GhostRecorder>().ResetData();
            //Destroy(gameObject);
            sr.material.color = Color.white;
            
        }
    }
    public void VFX()
    {
        Instantiate(deathVFX, this.transform.position, Quaternion.identity);
    }
    public void Die(bool toDie)
    {
        if(toDie)
        {


            gm.isPlayerDead = true;
            gm.numberOfTriesPerLevel[SceneManager.GetActiveScene().buildIndex]++;
           // Destroy(gameObject);
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            sr.material.color = Color.white;
            toDie = false;
           /// GetComponent<GhostRecorder>().ResetData();
            // ghost.canAdd = true;
            // ghost.AddPoints(positions);

        }
    }

    public void DieLaser()
    {


       // if (laserHit)
        // StopAllCoroutines();
       // {
           // laserHit = !laserHit;
            gm.isPlayerDeadLaser = true;
            gm.numberOfTriesPerLevel[SceneManager.GetActiveScene().buildIndex]++;
            // Destroy(gameObject);

            sr.material.color = Color.white;
            sr.material.color = Color.red;
            moveSpeed = 0f;
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            // laserHit = false;

            /// GetComponent<GhostRecorder>().ResetData();
            // ghost.canAdd = true;
            // ghost.AddPoints(positions);
        //}

    }

   
    
    
}
