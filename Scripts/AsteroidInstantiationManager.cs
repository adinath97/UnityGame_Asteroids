using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInstantiationManager : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] List<Transform> asteroidInstantiationPoints;
    [SerializeField] List<Transform> waypoints1;
    [SerializeField] List<Transform> waypoints2;
    [SerializeField] List<Transform> waypoints3;
    [SerializeField] List<Transform> waypoints4;
    [SerializeField] float moveSpeed = 4f;
    public static bool incrDifficulty;
    private float timer0,timerCap0,timer1,timerCap1,timer2,timerCap2,
     timer3,timerCap3,timer4,timerCap4,timer5,timerCap5,
     timer6,timerCap6,timer7,timerCap7,timer8,timerCap8,
     timer9,timerCap9,timer10,timerCap10,timer11,timerCap11,
     timer12,timerCap12,timer13,timerCap13,timer14,timerCap14,
     timer15,timerCap15;
    private float lowerBound, upperBound, angleRangeLowerBound = 100f, angleRangeUpperBound = 300f;
    private int waypointIndex1, waypointIndex2, waypointIndex3, waypointIndex4;
    
    // Start is called before the first frame update
    void Start()
    {
        incrDifficulty = false;
        lowerBound = 5f;
        upperBound = 10f;
        angleRangeLowerBound = 100f;
        angleRangeUpperBound = 300f;
        timerCap0 = Random.Range(lowerBound,upperBound);
        timerCap1 = Random.Range(lowerBound,upperBound);
        timerCap2 = Random.Range(lowerBound,upperBound);
        timerCap3 = Random.Range(lowerBound,upperBound);
    }

    // Update is called once per frame
    void Update()
    {
        timer0 += Time.deltaTime;
        timer1 += Time.deltaTime;
        timer2 += Time.deltaTime;
        timer3 += Time.deltaTime;

        if(timer0 > timerCap0) {
            timerCap0 = Random.Range(lowerBound,upperBound);
            timer0 = 0;
            Vector3 rot = asteroidInstantiationPoints[0].rotation.eulerAngles;
            rot = new Vector3(rot.x,rot.y,rot.z + Random.Range(angleRangeLowerBound,angleRangeUpperBound));
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[0].position,Quaternion.Euler(rot)) as GameObject;
            //asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(1f,3f),Random.Range(-3f,3f));
        }

        if(timer1 > timerCap1) {
            timer1 = 0;
            timerCap1 = Random.Range(lowerBound,upperBound);
            Vector3 rot = asteroidInstantiationPoints[1].rotation.eulerAngles;
            rot = new Vector3(rot.x,rot.y,rot.z + Random.Range(angleRangeLowerBound,angleRangeUpperBound));
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[1].position,Quaternion.Euler(rot)) as GameObject;
            //asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,-1f),Random.Range(-3f,3f));
        }

        if(timer2 > timerCap2) {
            timer2 = 0;
            timerCap2 = Random.Range(lowerBound,upperBound);
            Vector3 rot = asteroidInstantiationPoints[2].rotation.eulerAngles;
            rot = new Vector3(rot.x,rot.y,rot.z + Random.Range(angleRangeLowerBound,angleRangeUpperBound));
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[2].position,Quaternion.Euler(rot)) as GameObject;
            //asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,-1f));
        }

        if(timer3 > timerCap3) {
            timer3 = 0;
            timerCap3 = Random.Range(lowerBound,upperBound);
            Vector3 rot = asteroidInstantiationPoints[3].rotation.eulerAngles;
            rot = new Vector3(rot.x,rot.y,rot.z + Random.Range(angleRangeLowerBound,angleRangeUpperBound));
            GameObject asteroidInstance = Instantiate(asteroidPrefab,asteroidInstantiationPoints[3].position,Quaternion.Euler(rot)) as GameObject;
            //asteroidInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3f,3f),Random.Range(1f,3f));
        }

        if (waypointIndex1 <= waypoints1.Count - 1) {
            var targetPosition = waypoints1[waypointIndex1].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            asteroidInstantiationPoints[0].transform.position = Vector2.MoveTowards(asteroidInstantiationPoints[0].transform.position, targetPosition, movementThisFrame);
            if (asteroidInstantiationPoints[0].transform.position == targetPosition)
            {
                waypointIndex1++;
                if(waypointIndex1 == waypoints1.Count) {
                    waypointIndex1 = 0;
                }
            }
        }

        if (waypointIndex2 <= waypoints2.Count - 1) {
            var targetPosition = waypoints2[waypointIndex2].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            asteroidInstantiationPoints[1].transform.position = Vector2.MoveTowards(asteroidInstantiationPoints[1].transform.position, targetPosition, movementThisFrame);
            if (asteroidInstantiationPoints[1].transform.position == targetPosition)
            {
                waypointIndex2++;
                if(waypointIndex2 == waypoints2.Count) {
                    waypointIndex2 = 0;
                }
            }
        }

        if (waypointIndex3 <= waypoints3.Count - 1) {
            var targetPosition = waypoints3[waypointIndex3].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            asteroidInstantiationPoints[2].transform.position = Vector2.MoveTowards(asteroidInstantiationPoints[2].transform.position, targetPosition, movementThisFrame);
            if (asteroidInstantiationPoints[2].transform.position == targetPosition)
            {
                waypointIndex3++;
                if(waypointIndex3 == waypoints3.Count) {
                    waypointIndex3 = 0;
                }
            }
        }

        if (waypointIndex4 <= waypoints4.Count - 1) {
            var targetPosition = waypoints4[waypointIndex4].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            asteroidInstantiationPoints[3].transform.position = Vector2.MoveTowards(asteroidInstantiationPoints[3].transform.position, targetPosition, movementThisFrame);
            if (asteroidInstantiationPoints[3].transform.position == targetPosition)
            {
                waypointIndex4++;
                if(waypointIndex4 == waypoints4.Count) {
                    waypointIndex4 = 0;
                }
            }
        }

        if(incrDifficulty) {
            incrDifficulty = false;
            if(angleRangeLowerBound < 160f) {
                angleRangeLowerBound += 5f;
            }
            if(angleRangeUpperBound > 200f) {
                angleRangeUpperBound -= 5f;
            }
            if(lowerBound > 5f) {
                lowerBound -=  1f;
            }
            if(upperBound > 10f) {
                upperBound -= 1f;
            }
        }
    }
}
