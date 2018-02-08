using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalToilet_chikazawa : MonoBehaviour
{
    public ParticleSystem particle;
    public float timer = 5;
   public bool torriger=false;
    // Use this for initialization
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();

        particle.Stop(true);
    }
    void Update()
    {
        if (torriger == true)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            SceneManager.LoadScene("Game_chikazawa");
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
            if (col.gameObject.tag == "Player")
            {
                torriger = true;
                particle.Play(); //パーティクルの再生
            }
    }
}