using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    private int height = 40;
    private int width = 25;


    AudioSource fuenteDeAudio;
    [SerializeField] private GameObject powerup;
    [SerializeField] private GameObject bola;
    private Rigidbody2D rb;
    [SerializeField] private AudioClip audio;

    // Start is called before the first frame update
    void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();
        float xPos = Random.Range(-height/2, width/2);
        float yPos = Random.Range(-height/2, width/2);
        powerup.transform.position = new Vector3(xPos, yPos, 0);

        rb = bola.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == bola)
        {
            rb.velocity = -rb.velocity;
            randomPos();
            fuenteDeAudio.clip = audio;
            fuenteDeAudio.Play();
        }
    }

    void randomPos()
    {
        float xPos = Random.Range(-height/2, width/2);
        float yPos = Random.Range(-height/2, width/2);
        powerup.transform.position = new Vector3(xPos, yPos, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
