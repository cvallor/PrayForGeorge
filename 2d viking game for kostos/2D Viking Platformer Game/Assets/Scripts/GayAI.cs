using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GayAI : MonoBehaviour {

    public float Speed;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Patrol"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
            Flip();
        }
    }

    void Flip()
    {
        Vector3 LocalScale = transform.localScale;
        LocalScale.x *= -1;
        transform.localScale = LocalScale;
    }
}
