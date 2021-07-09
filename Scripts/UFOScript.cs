using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] List<Transform> possibleTargetPositions;
    [SerializeField] Transform laserInstantiationPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] AudioClip[] enemySounds;
    private AudioSource myAudioSource;
    Transform targetPosition;
    bool beginMovement;
    private float timer, timerCap;
    public bool instantiated;
    
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
        myAudioSource = this.GetComponent<AudioSource>();
        timerCap = Random.Range(3f,6f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timerCap && instantiated) {
            timerCap = Random.Range(3f,6f);
            timer = 0;
            AudioClip clip = enemySounds[0];
            myAudioSource.PlayOneShot(clip);
            Instantiate(bulletPrefab,laserInstantiationPoint.position,transform.rotation);
        }
        if(beginMovement) {
            this.transform.position = Vector2.MoveTowards(this.transform.position,targetPosition.transform.position,moveSpeed*Time.deltaTime);
        }
        if(beginMovement && transform.position == targetPosition.position) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerBullet" && beginMovement) {
            AudioClip clip = enemySounds[1];
            myAudioSource.PlayOneShot(clip);
            if(other.gameObject.tag == "PlayerBullet") {
                ScoreManager.score += 100f;
                ScoreManager.diffScore += 100f;
            }
            GameObject deathExplosionInstance = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "AsteroidOne" || 
            other.gameObject.tag == "AsteroidTwo" || other.gameObject.tag == "AsteroidZero") {
            AudioClip clip = enemySounds[1];
            myAudioSource.PlayOneShot(clip);
            GameObject deathExplosionInstance = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
        }
    }

    private void SetUp() {
        if(this.transform.position == possibleTargetPositions[0].position || this.transform.position == possibleTargetPositions[1].position) {
            int randX = Mathf.RoundToInt(Random.Range(0f,10f));
            if(randX % 2 == 0) {
                targetPosition = possibleTargetPositions[4];
            }
            else {
                targetPosition = possibleTargetPositions[5];
            }
            beginMovement = true;
        }
        else if(this.transform.position == possibleTargetPositions[4].position || this.transform.position == possibleTargetPositions[5].position) {
            int randX = Mathf.RoundToInt(Random.Range(0f,10f));
            if(randX % 2 == 0) {
                targetPosition = possibleTargetPositions[0];
            }
            else {
                targetPosition = possibleTargetPositions[1];
            }
            beginMovement = true;
        }
        else if(this.transform.position == possibleTargetPositions[2].position || this.transform.position == possibleTargetPositions[3].position) {
            int randX = Mathf.RoundToInt(Random.Range(0f,10f));
            if(randX % 2 == 0) {
                targetPosition = possibleTargetPositions[6];
            }
            else {
                targetPosition = possibleTargetPositions[7];
            }
            beginMovement = true;
        }
        else if(this.transform.position == possibleTargetPositions[6].position || this.transform.position == possibleTargetPositions[7].position) {
            int randX = Mathf.RoundToInt(Random.Range(0f,10f));
            if(randX % 2 == 0) {
                targetPosition = possibleTargetPositions[2];
            }
            else {
                targetPosition = possibleTargetPositions[3];
            }
            beginMovement = true;
        }
    }

}
