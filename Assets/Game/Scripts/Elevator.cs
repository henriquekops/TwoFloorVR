using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public Vector3 firstFloor;
    public Vector3 secondFloor;
    public Player player;

    private bool changeFloor;
    private bool up;

    void Start()
    {
        changeFloor = false;
        up = true;
    }

    void Update()
    {
        if (changeFloor)
        {
            if (up)
            {
                if (transform.position.y <= 12)
                {
                    transform.position += transform.up * Time.deltaTime;
                }
                else 
                {
                    up = false;
                    changeFloor = false;
                    player.transform.parent = null;
                }
            }
            else
            {
                if (transform.position.y > 0)
                {
                    transform.position -= transform.up * Time.deltaTime;
                }
                else
                {
                    up = true;
                    changeFloor = false;
                    player.transform.parent = null;
                }
            }
        }
    }

    public void ChangeFloor()
    {
        player.transform.parent = transform;
        changeFloor = true;
    }
}
