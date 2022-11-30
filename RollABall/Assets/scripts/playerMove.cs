using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;

    public int score = 0;
    public int scoreIncremeten = 10;

    public Text wintext;
    public Text errortext;
    public Text scoretext;

    public AudioSource coinCollectSound;
    public AudioSource hitwallSound;
    public AudioSource errorSound;
    public AudioSource rollSound;
    public AudioSource winSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        float hori;
        float vert;

        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Vector3 kuvvet = new Vector3(hori, 0f, vert);
        rb.AddForce(kuvvet * speed);
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(new Vector3(0, 200f, 0)* Time.deltaTime * speed);
        }

    }

    private void OnCollisionEnter(Collision coin)
    {
        if (coin.gameObject.CompareTag("wall"))
        {
            hitwallSound.Play();
        }
        if (coin.gameObject.CompareTag("floor"))
        {
            rollSound.Play();
        }
        if (coin.gameObject.CompareTag("coin"))
        {
            Destroy(coin.gameObject);
            coinCollectSound.Play();
            score = score + scoreIncremeten;
            scoretext.text = "Score: " + score.ToString();
        }
        if (score == 70 && coin.gameObject.CompareTag("coins"))
        {
            Destroy(coin.gameObject);
            coinCollectSound.Play();
            score = score + scoreIncremeten;
            scoretext.text = "Score: " + score.ToString();
            if(score == 80)
            {
                winSound.Play();
                wintext.text = "KAZANDINIZ";
                StartCoroutine(win());
            }
        }
        else if (coin.gameObject.CompareTag("coins"))
        {
            errorSound.Play();
            errortext.text = "Bu Top En Son Alýnacaktýr!!!!";
            StartCoroutine(error());
        }
    }
    IEnumerator error()
    {
        yield return new WaitForSeconds(2);
        errortext.text = "";
    }
    IEnumerator win()
    {
        yield return new WaitForSeconds(5);
        wintext.text = "";
        SceneManager.LoadScene("SampleScene");
    }
}
