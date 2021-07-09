using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Image> livesImages;
    public static bool removeLife;
    
    // Start is called before the first frame update
    void Start()
    {
        removeLife = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(removeLife) {
            removeLife = false;
            Image tempImage = livesImages[livesImages.Count -1];
            livesImages.RemoveAt(livesImages.Count - 1);
            Destroy(tempImage);
        }
    }
}
