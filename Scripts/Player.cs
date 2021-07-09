using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 300f;
    [SerializeField] GameObject playerLaserPrefab;
    [SerializeField] float laserMoveSpeed = 100f;
    [SerializeField] Transform laserInstantiationPoint;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] AudioClip[] playerSounds;
    private Rigidbody2D myRigidbody;
    private AudioSource myAudioSource;
    private bool fireAgain, thisGameOver, allowHit;
    private float firingRate = .25f, moveSpeed = 0f;

    public string currentTriggerTag;

    public bool justWentThrough = false;

    public static bool checkFiring = false, beginGame;
    private int lives;

    void Awake()
    {
        speed = 300f;
    }
    
    void Start()
    {
        myAudioSource = this.GetComponent<AudioSource>();
        fireAgain = true;
        beginGame = false;
        StartCoroutine(StartFlash());
        lives = 3;
        justWentThrough = false;
        thisGameOver = false;
        myRigidbody = this.GetComponent<Rigidbody2D>();
        
    }

    private void Update() {
        Fire();
        Move();
        if(checkFiring) {
            fireAgain = true;
            checkFiring = false;
        }
    }

    private void Move() {
        if(Input.GetKey(KeyCode.UpArrow)) {
            myRigidbody.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
            
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void Fire() {
        if(Input.GetKey(KeyCode.Space)) {
            if(fireAgain && !thisGameOver) {
                fireAgain = false;
                StartCoroutine(FireRoutine());
            }
        }
    }

    IEnumerator FireRoutine() {
        yield return new WaitForSeconds(firingRate);
        AudioClip clip = playerSounds[0];
        myAudioSource.PlayOneShot(clip);
        GameObject laserInstance1 = Instantiate(playerLaserPrefab,laserInstantiationPoint.position,this.transform.rotation) as GameObject;
        //laserInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.fixedDeltaTime);
        //GameObject laserInstance2 = Instantiate(playerLaserPrefab,laserInstantiationPoint.position,Quaternion.identity) as GameObject;
        //laserInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserMoveSpeed * Time.fixedDeltaTime);
        fireAgain = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "AsteroidOne" || other.gameObject.tag == "AsteroidTwo" || other.gameObject.tag == "AsteroidZero") {
            if(other.gameObject.tag == "EnemyBullet") {
                Destroy(other.gameObject);
            }
            if(allowHit) {
                allowHit = false;
                lives--;
                if(this.lives > 0) {
                    AudioClip clip = playerSounds[1];
                    myAudioSource.PlayOneShot(clip);
                    this.GetComponent<SpriteRenderer>().enabled = false;
                    GameObject deathExplosionInstance = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
                    myRigidbody.velocity = Vector2.zero;
                    this.transform.position = Vector3.zero;
                    moveSpeed = 0;
                    GameManager.removeLife = true;
                    StartCoroutine(StartFlash());
                }
                else {
                    Debug.Log("HELLO THERE!");
                    AudioClip clip = playerSounds[1];
                    myAudioSource.PlayOneShot(clip);
                    GameManager.removeLife = true;
                    GameObject deathExplosionInstance = Instantiate(deathExplosion,transform.position,Quaternion.identity) as GameObject;
                    GameSceneManager.gameOver = true;
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private IEnumerator StartFlash() {
        this.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.25f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.25f);
        this.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.25f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.25f);
        this.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.25f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.25f);
        this.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.25f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.25f);
        this.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.25f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.25f);
        this.GetComponent<SpriteRenderer>().enabled = true;
        moveSpeed = .05f;
        allowHit = true;
    }
    
}
