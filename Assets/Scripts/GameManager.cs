using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pausesPerLevel;
    public List<int> numberOfTriesPerLevel;
    public List<int> bestTime;
    public Text tries;
    public Text timer;
    public bool isPlayerDead;
    public bool isPlayerDeadLaser;
    [SerializeField]
    private GameObject player;
    public Transform respawnPoint;
    public static bool hasAddedPositions;
    public GhostPlayer ghost;
    public GhostEntity ghostEnt;
    public GhostReplayer ghost2;
    
    public  List<int> bestTries;

    private GameObject playerPref;
    private float startTime;
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        tries.text = "Tries: 0";
        isPlayerDead = false;
        startTime = Time.time;
        timer.text = "0:00";
        hasAddedPositions = false;
        player = GameObject.FindGameObjectWithTag("Player");
        isPlayerDeadLaser = false;
        // playerPref = player;
        //PlayerPrefs.SetInt("BestTriesLevel1", 99999);

        //playerPref.gameObject.GetComponent<PlayerController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayNumberOfTriesPerLevel();
        /*if (PlayerPrefs.GetInt("LeastTries" + SceneManager.GetActiveScene().buildIndex) < numberOfTriesPerLevel[SceneManager.GetActiveScene().buildIndex])
        {
            PlayerPrefs.SetInt("LeastTries" + SceneManager.GetActiveScene().buildIndex, numberOfTriesPerLevel[SceneManager.GetActiveScene().buildIndex]);
        }*/
        Debug.Log(PlayerPrefs.GetInt("BestTriesLevel1"));
        if(PlayerPrefs.GetInt("BestTriesLevel1")<bestTries[SceneManager.GetActiveScene().buildIndex])
        {
            PlayerPrefs.SetInt("BestTriesLevel1", bestTries[SceneManager.GetActiveScene().buildIndex]);
        }
        if (PlayerPrefs.GetInt("BestTriesLevel2") < bestTries[SceneManager.GetActiveScene().buildIndex])
        {
            PlayerPrefs.SetInt("BestTriesLevel2", bestTries[SceneManager.GetActiveScene().buildIndex]);
        }
        if (PlayerPrefs.GetInt("BestTriesLevel3") < bestTries[SceneManager.GetActiveScene().buildIndex])
        {
            PlayerPrefs.SetInt("BestTriesLevel3", bestTries[SceneManager.GetActiveScene().buildIndex]);
        }
        if (PlayerPrefs.GetInt("BestTriesLevel4") < bestTries[SceneManager.GetActiveScene().buildIndex])
        {
            PlayerPrefs.SetInt("BestTriesLevel4", bestTries[SceneManager.GetActiveScene().buildIndex]);
        }


       
        




        // player = GameObject.FindGameObjectWithTag("Player");
        //if (isPlayerDead)


        //{

        //}



    }
    void LateUpdate()
    {
        Respawn();
    }
    
    public void DisplayNumberOfTriesPerLevel()
    {
        tries.text = "Tries: " + numberOfTriesPerLevel[SceneManager.GetActiveScene().buildIndex];
        time = Time.time - startTime;
        Debug.Log(time);
        string minutes = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString("f0");
        Debug.Log(minutes + " : " + seconds);
        timer.text = "" + minutes + " : " + seconds;
    }

    public void Respawn()
    {
        if (isPlayerDead)
        {
            // ghost.gameObject.transform.position = respawnPoint.position;
            // ghost.gameObject.SetActive(true);
            //  ghostEnt.isRecording = true;
            //  ghostEnt.isReplaying = true;
           // ghost.gameObject.SetActive(true);
           
            //ghost.gameObject.transform.position = player.gameObject.GetComponent<PlayerController>().positions[200].position;
           // ghost.AddPoints(player.gameObject.GetComponent<PlayerController>().positions);
            player.SetActive(false);
            
            //ghost.gameObject.SetActive(true);
            //ghost.move = true;
            ghost2.timeStamp = new List<float>(ghostEnt.timeStamp);
            ghost2.position = new List<Vector3>(ghostEnt.position);
            // ghost2.timeStamp[i] = ghostEnt.timeStamp[i];


            ghostEnt.ResetData();
            /* for(int i =0;i<ghostEnt.position.Count;i++)
             {
                 ghost2.timeStamp[i]  = ghostEnt.timeStamp[i];
                 ghost2.position[i] = ghostEnt.position[i];
                 ghost2.timeStamp[i]  = ghostEnt.timeStamp[i];
             }

             ghostEnt.ResetData();*/
            // StartCoroutine(WaitRespawn());
            //hasAddedPositions = true;

            StartCoroutine(WaitToRespawn());
        }
         if(isPlayerDeadLaser)
        {
            StartCoroutine(Wait());
        }
                
    }

   /* private IEnumerator WaitRespawn()
    {
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
        player.transform.position = respawnPoint.position;
        isPlayerDead = false;
    }*/


    private IEnumerator WaitToRespawn()
    {
        yield return new WaitForSeconds(1f);
        player.SetActive(true);
        player.transform.position = respawnPoint.position;
        player.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        isPlayerDead = false;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        
       // player.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        player.SetActive(false);
        //yield return StartCoroutine(WaitToRespawn());
        yield return new WaitForSeconds(1f);
        player.GetComponent<SpriteRenderer>().material.color = Color.white;
        player.GetComponent<PlayerController>().moveSpeed = player.GetComponent<PlayerController>().initialSpeed;
        player.SetActive(true);
        player.transform.position = respawnPoint.position;
        isPlayerDeadLaser = false;
        player.gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }

    

    

    
}
