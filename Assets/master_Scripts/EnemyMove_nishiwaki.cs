using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_nishiwaki : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("あたった");
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("コリジョン");
    }
}
