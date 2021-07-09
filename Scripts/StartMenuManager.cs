using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] GameObject startFade;
    
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(StartFade());
    }

    private IEnumerator StartFade() {
        startFade.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        startFade.SetActive(false);
    }
}
