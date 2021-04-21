using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour
{
    public GameManager gm;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            /*if (PlayerPrefs.GetInt("BestTriesLevel" + index.ToString() )> gm.numberOfTriesPerLevel[SceneManager.GetActiveScene().buildIndex])
            {
                PlayerPrefs.SetInt("BestTriesLevel" + index.ToString(), gm.numberOfTriesPerLevel[SceneManager.GetActiveScene().buildIndex]);
            }*/
             if (PlayerPrefs.GetInt("BestTriesLevel1") > gm.numberOfTriesPerLevel[SceneManager.GetActiveScene().buildIndex])
             {
                 PlayerPrefs.SetInt("BestTriesLevel1", gm.numberOfTriesPerLevel[SceneManager.GetActiveScene().buildIndex]);
             }

            Scene sceneLoaded = SceneManager.GetActiveScene();
            SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
            
           
        }
    }
}
