using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUFOInstantiator : MonoBehaviour
{
    [SerializeField] GameObject UFOPrefab;
    [SerializeField] List<Transform> UFOInstantiationPoints;

    private float timer = 0, timerCap;
    
    // Start is called before the first frame update
    void Start()
    {
        timerCap = Random.Range(10f,15f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timerCap) {
            timer = 0;
            timerCap = Random.Range(10f,15f);
            int randX = Random.Range(0,UFOInstantiationPoints.Count);
            GameObject UFOInstance = Instantiate(UFOPrefab,UFOInstantiationPoints[randX].position,Quaternion.identity);
            UFOInstance.GetComponent<UFOScript>().instantiated = true;
        }
    }
}
