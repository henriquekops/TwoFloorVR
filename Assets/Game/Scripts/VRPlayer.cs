using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayer : MonoBehaviour
{

    private Transform itemSlot;
    public bool gazing;

    void Start()
    {
        itemSlot = transform.GetChild(0).transform;
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (itemSlot.childCount == 0)
            {
                if (hit.transform.tag == "interactive")
                {
                    gazing = true;
                    hit.transform.GetComponent<InteractiveObject>().Gazing();
                }
                else if (hit.transform.tag == "button")
                {
                    gazing = true;
                    hit.transform.GetComponent<InteractiveObject>().Gazing();
                }
                else
                {
                    gazing = false;
                }
            }
            else
            {
                if (hit.transform.tag == "button")
                {
                    gazing = true;
                    hit.transform.GetComponent<InteractiveObject>().Gazing();
                }
                else
                {
                    gazing = false;
                }
            }
        }
    }
}
