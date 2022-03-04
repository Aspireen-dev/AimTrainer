using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float size;
    public float Size
    {
        get
        {
            return size;
        }
    }
    private bool maxSized = false;

    void Start()
    {
        size = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0f && !maxSized)
        {
            size += Time.deltaTime;
            if (size > 5)
            {
                size = 5;
                maxSized = true;
            }
            transform.localScale = new Vector3(size, size, size);
        }
    }
}
