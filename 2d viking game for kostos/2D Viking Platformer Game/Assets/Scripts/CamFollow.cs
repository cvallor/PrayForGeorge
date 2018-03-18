using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    private GameObject Player;

    private Vector2 StartVec;

    public float Max_X;

    void Start () {
        StartVec = transform.position;
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Player != null)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
        }
    }
}
