using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;
    [SerializeField] GameObject startFade;
    [SerializeField] Text newHighScoreAlert;

    void Awake()
    {
        StartCoroutine(StartFade());
        if(ScoreManager.newHighScore) {
            ScoreManager.newHighScore = false;
            newHighScoreAlert.text = "NEW HIGH SCORE! HURRAY!";
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = Mathf.RoundToInt(ScoreManager.score).ToString();
        highScoreText.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("HighScore",0f)).ToString();
    }

    private IEnumerator StartFade() {
        startFade.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        startFade.SetActive(false);
    }
}
