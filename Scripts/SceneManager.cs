using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] GameObject endFade;
    private static bool allowClicking;

    void Awake()
    {
        allowClicking = true;
        endFade.SetActive(false);
    }
    
    public void LoadStartMenu() {
        allowClicking = false;
        StartCoroutine(WaitAndLoad1());
    }

    private IEnumerator WaitAndLoad1() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenuScene");
    }

    public void LoadGameScene() {
        allowClicking = false;
        StartCoroutine(WaitAndLoad2());
    }

    private IEnumerator WaitAndLoad2() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void LoadGameOverScene() {
        allowClicking = false;
        StartCoroutine(WaitAndLoad3());
    }

    private IEnumerator WaitAndLoad3() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }

    public void LoadCreditsScene() {
        allowClicking = false;
        StartCoroutine(WaitAndLoad4());
    }

    private IEnumerator WaitAndLoad4() {
        endFade.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditsScene");
    }

    public void QuitGame() {
        allowClicking = false;
        Application.Quit();
    }
}
