using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundco : MonoBehaviour
{
    public float movespeed = 1f;
    private float startX;
    private float backgroundWidth;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        backgroundWidth = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * movespeed * Time.deltaTime;
        if (transform.position.x <= startX - backgroundWidth)
            transform.position += Vector3.right * backgroundWidth;


    }
}
