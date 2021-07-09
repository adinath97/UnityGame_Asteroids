using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] GameObject startFade;
    [SerializeField] GameObject endFade;
    public static bool gameOver;
    
    void Awake()
    {
        StartCoroutine(StartFadeRoutine());
    }

    private IEnumerator StartFadeRoutine() {
        gameOver = false;
        startFade.SetActive(true);
        endFade.SetActive(false);
        yield return new WaitForSeconds(2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver) {
            StartCoroutine(EndFadeRoutine());
        }
    }

    private IEnumerator EndFadeRoutine() {
        gameOver = false;
        endFade.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
        //endFade.SetActive(false);
    }
}
