using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractiveObject
{

    public override void Action()
    {
        transform.parent.GetComponent<Elevator>().ChangeFloor();
    }
}
