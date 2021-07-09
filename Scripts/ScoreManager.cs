using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject scoreBox;
    public static float score, timer, diffScore;
    public static bool newHighScore;
    Text scoreHolder;
    
    // Start is called before the first frame update
    void Start()
    {
        newHighScore = false;
        score = 0;
        timer = 0;
        diffScore = 0;
        scoreHolder = scoreBox.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreHolder.text = Mathf.RoundToInt(score).ToString();
        if(diffScore > 1000f) {
            diffScore = 0f;
            AsteroidInstantiationManager.incrDifficulty = true;
        }
        if(score > PlayerPrefs.GetFloat("HighScore",0f)) {
            newHighScore = true;
            PlayerPrefs.SetFloat("HighScore",score);
        }
    }
}
