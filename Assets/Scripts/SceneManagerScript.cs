using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private AudioManager audioManager;

    public RectTransform mainMenu, highScoreMenu;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        StartCoroutine(WaitLoad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBackgroundOrScene(string sceneName)
    {
        audioManager.PlaySound("buttonClickSound");
        StartCoroutine(ChangeScene(sceneName));
       
    }

    public void ChangeBackgroundOrScene()
    {
        //SceneManager.LoadScene(sceneName);
        audioManager.PlaySound("buttonClickSound");
    }

    public void HighScoreMenu()
    {
        audioManager.PlaySound("buttonClickSound");
        StartCoroutine(WaitHighScoreMenu());
       

    }

    public void MainMenu()
    {
        audioManager.PlaySound("buttonClickSound");
        StartCoroutine(WaitMainMenu());
     

    }

    public void QuitApp()
    {
        audioManager.PlaySound("buttonClickSound");
        StartCoroutine(DelayLoad());
    }

    private IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }



    private IEnumerator WaitLoad()
    {
        yield return new WaitForSeconds(1f);
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    private IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }

    private IEnumerator WaitMainMenu()
    {
        highScoreMenu.DOAnchorPos(new Vector2(1920, 0), 0.25f);
        yield return new WaitForSeconds(0.5f);
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        yield return new WaitForSeconds(0.5f);
        audioManager.PlaySound("loadCompleteSound");

    }

    private IEnumerator WaitHighScoreMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(-1920, 0), 0.25f);
        yield return new WaitForSeconds(0.5f);
        highScoreMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        yield return new WaitForSeconds(0.5f);
        audioManager.PlaySound("loadCompleteSound");

    }


}
