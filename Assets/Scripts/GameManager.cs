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

    public  List<int> bestTries;

    private GameObject playerPref;
    
    // Start is called before the first frame update
    void Start()
    {
        tries.text = "Tries: 0";
        isPlayerDead = false;
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
            player.SetActive(false);
            // StartCoroutine(WaitRespawn());
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
