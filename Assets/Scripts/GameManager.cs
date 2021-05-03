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
    public bool isPlayerDead;
    [SerializeField]
    private GameObject player;
    public Transform respawnPoint;
    public static bool hasAddedPositions;
    public GhostPlayer ghost;
    public GhostEntity ghostEnt;
    public GhostReplayer ghost2;

    public  List<int> bestTries;

    private GameObject playerPref;
    
    // Start is called before the first frame update
    void Start()
    {
        tries.text = "Tries: 0";
        isPlayerDead = false;
        hasAddedPositions = false;
        player = GameObject.FindGameObjectWithTag("Player");
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
            ghost.gameObject.SetActive(true);
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

            player.SetActive(true);
            player.transform.position = respawnPoint.position;
            isPlayerDead = false;
        }
    }

   /* private IEnumerator WaitRespawn()
    {
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
        player.transform.position = respawnPoint.position;
        isPlayerDead = false;
    }*/

    

    
}
