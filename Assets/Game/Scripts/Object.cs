using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : InteractiveObject
{
    public Transform itemSlot;

    private bool picked = false;

    public override void Action()
    {
        if (picked == false)
        {
            PickUp();
        }
        else
        {
            ThrowAway();
        }
    }

    public void PickUp()
    {
        picked = true;
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
        //GetComponent<Rigidbody>().freezeRotation = true;
        transform.position = itemSlot.position;
        transform.parent = GameObject.Find("ItemSlot").transform;
        timer = 0.0f;
    }

    public void ThrowAway()
    {
        picked = false;
        transform.parent = null;
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
        timer = 0.0f;
    }
}
