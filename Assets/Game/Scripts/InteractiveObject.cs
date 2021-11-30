using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public Material off = null;
    public Material on = null;
    public float gazeThreshold = 3.0f;

    protected Renderer renderer;
    protected float timer;
    protected bool gazing = false;

    void Start()
    {
        timer = 0.0f;
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
        renderer.sharedMaterial = off;
    }

    void Update()
    {
        if (gazing == false)
        {
            timer = 0.0f;
            renderer.sharedMaterial = off;
        }
        gazing = false;
    }

    public void Gazing()
    {
        gazing = true;
        renderer.sharedMaterial = on;
        timer += Time.deltaTime;
        if (timer >= gazeThreshold)
        {
            Action();
        }
    }

    public virtual void Action() 
    {
        // Do nothing
    }
}
