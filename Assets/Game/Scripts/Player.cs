using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform vrPlayer = null;
    public float moveInitThreshold = 25.0f;
    public float moveEndThreshold = 90.0f;
    public float objPlaceInitThreshold = 90.0f;
    public float objPlaceEndThreshold = 100.0f;
    public float speed = 3.0f;
    public bool move;

    private CharacterController ctl;
    private Transform itemSlot;

    void Start()
    {
        ctl = GetComponent<CharacterController>();
        itemSlot = vrPlayer.GetChild(0).gameObject.transform;
    }

    void Update()
    {
        if (!vrPlayer.GetComponent<VRPlayer>().gazing)
        {
            if (vrPlayer.eulerAngles.x >= moveInitThreshold && vrPlayer.eulerAngles.x < moveEndThreshold)
            {
                ctl.SimpleMove(vrPlayer.TransformDirection(Vector3.forward) * speed);
            }
            else if (vrPlayer.eulerAngles.x >= moveEndThreshold && vrPlayer.eulerAngles.x < 100.0f) 
            {
                if (itemSlot.childCount > 0)
                {
                    InteractiveObject iObject = itemSlot.GetChild(0).gameObject.GetComponent<InteractiveObject>();
                    iObject.Gazing();
                }
            }
        }
    }
}
