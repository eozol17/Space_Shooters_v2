using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSBeh : MonoBehaviour
{
    [SerializeField]private float speed = 3;
    [SerializeField] private int puID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -6.81f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player == null) return;
            
            if (puID == 0)
            {
                player.TSCollected();
                Destroy(this.gameObject);
            }
            else if(puID == 1)
            {
                player.speedCollected();
                Destroy(this.gameObject);
            }
            else if (puID == 1)
            {
                player.speedCollected();
                Destroy(this.gameObject);
            }

        }
    }
}
