using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.down) * Speed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            transform.position = new Vector3(Random.Range(-9.3f, 9.3f), 8.26f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Lazer")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
