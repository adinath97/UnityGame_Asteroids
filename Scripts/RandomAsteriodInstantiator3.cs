using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAsteriodInstantiator3 : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] List<Transform> asteroidInstantiationPoints;
    private float timer0,timerCap0,timer1,timerCap1,timer2,timerCap2,
     timer3,timerCap3,timer4,timerCap4,timer5,timerCap5,
     timer6,timerCap6,timer7,timerCap7;

    private float lowerBound = 5f, upperBound = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        timerCap0 = Random.Range(lowerBound,upperBound);
        timerCap1 = Random.Range(lowerBound,upperBound);
        timerCap2 = Random.Range(lowerBound,upperBound);
        timerCap3 = Random.Range(lowerBound,upperBound);
        timerCap4 = Random.Range(lowerBound,upperBound);
        timerCap5 = Random.Range(lowerBound,upperBound);
        timerCap6 = Random.Range(lowerBound,upperBound);
        timerCap7 = Random.Range(lowerBound,upperBound);
    }

    // Update is called once per frame
    void Update()
    {
        timer0 += Time.deltaTime;
        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
        timer3 += Time.deltaTime;
        timer4 += Time.deltaTime;
        timer5 += Time.deltaTime;
        timer6 += Time.deltaTime;
        timer7 += Time.deltaTime;

        if(timer0 > timerCap0) {
            timer0 = 0f;
            timerCap0 = Random.Range(lowerBound,upperBound);
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[0].position,Quaternion.identity);
            //asteroidInstance.GetComponent<AsteroidMoveTowardsPlayer>().moveSpeed = 0f;
            asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
        }
        if(timer1 > timerCap1) {
            timer1 = 0f;
            timerCap1 = Random.Range(lowerBound,upperBound);
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[1].position,Quaternion.identity);
            //asteroidInstance.GetComponent<AsteroidMoveTowardsPlayer>().moveSpeed = 0f;
            asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
        }
        if(timer2 > timerCap2) {
            timer2 = 0f;
            timerCap2 = Random.Range(lowerBound,upperBound);
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[2].position,Quaternion.identity);
            //asteroidInstance.GetComponent<AsteroidMoveTowardsPlayer>().moveSpeed = 0f;
            asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
        }
        if(timer3 > timerCap3) {
            timer3 = 0f;
            timerCap3 = Random.Range(lowerBound,upperBound);
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[3].position,Quaternion.identity);
            //asteroidInstance.GetComponent<AsteroidMoveTowardsPlayer>().moveSpeed = 0f;
            asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
        }
        if(timer4 > timerCap4) {
            timer4 = 0f;
            timerCap4 = Random.Range(lowerBound,upperBound);
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[4].position,Quaternion.identity);
            //asteroidInstance.GetComponent<AsteroidMoveTowardsPlayer>().moveSpeed = 0f;
            asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
        }
        if(timer5 > timerCap5) {
            timer5 = 0f;
            timerCap5 = Random.Range(lowerBound,upperBound);
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[5].position,Quaternion.identity);
            //asteroidInstance.GetComponent<AsteroidMoveTowardsPlayer>().moveSpeed = 0f;
            asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
        }
        if(timer6 > timerCap6) {
            timer6 = 0f;
            timerCap6 = Random.Range(lowerBound,upperBound);
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[6].position,Quaternion.identity);
            //asteroidInstance.GetComponent<AsteroidMoveTowardsPlayer>().moveSpeed = 0f;
            asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
        }
        if(timer7 > timerCap7) {
            timer7 = 0f;
            timerCap7 = Random.Range(lowerBound,upperBound);
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[7].position,Quaternion.identity);
            //asteroidInstance.GetComponent<AsteroidMoveTowardsPlayer>().moveSpeed = 0f;
            asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
        }
    }
}
