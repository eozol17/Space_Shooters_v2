using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float Hspeed = 5.5f;
    public float Vspeed = 2.5f;
    public float canFire = -1f;
    public float fireRate = 0.2f;
    public Vector3 offsetVec = new Vector3(0, 1.2f, 0);
    public Vector3 trioffsetVec = new Vector3(0, 3.2f, 0);
    [SerializeField] public GameObject lazer;
    [SerializeField] public GameObject tripleLazer;
    [SerializeField] public GameObject shield;
    [SerializeField] private bool tripleShotActive = false;
    [SerializeField] private bool shieldsActive = false;
    private int lives = 3;
    private SpawnManager spawnManager;

    private void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if(spawnManager == null)
        {
            Debug.LogError("SpawnManager is null");
        }
    }

    void Update()
    {
        movement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            FireLazer();
        }
    }
    
    
    
    void movement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput * Hspeed, verticalInput * Vspeed, 0);
        transform.Translate(direction * Time.deltaTime);

        if (transform.position.x < -11.27)
        {
            transform.position = new Vector3(11.32f, transform.position.y, 0);
        }
        else if (transform.position.x > 11.32)
        {
            transform.position = new Vector3(-11.27f, transform.position.y, 0);
        }
        //mathf.clamp makes a value between 2 given values
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 0), 0);
    }

    void FireLazer()
    {
        if (tripleShotActive)
        {
            canFire = Time.time + fireRate;
            Instantiate(tripleLazer, transform.position + trioffsetVec, Quaternion.identity);
        }
        else
        {
            canFire = Time.time + fireRate;
            Instantiate(lazer, transform.position + offsetVec, Quaternion.identity);
        }

    }

    public void Damage()
    {
        if(shieldsActive)
        {
            shieldsActive = false;
            return;
        }
        lives--;
        if(lives <= 0)
        {
            spawnManager.onPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TSCollected()
    {
        tripleShotActive = true;
        StartCoroutine(tripleShotPowerDownRoutine());
    }

    IEnumerator tripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        tripleShotActive = false;
    }

    public void speedCollected()
    {
        Hspeed *= 2;
        Vspeed *= 2;
        StartCoroutine(SpeedDown());
    }

    IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(5.0f);
        Hspeed /= 2;
        Vspeed /= 2;

    }
    public void shieldCollected()
    {
        //Instantiate(shield, transform.position + trioffsetVec, Quaternion.identity);
        shieldsActive = true;
    }
}
