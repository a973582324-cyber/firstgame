using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rd;
    public logicmanager manager;
    public float flapstrength = 5f;
    public float rotationSpeed = 5f;
    public bool birdalive = true;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("logic").GetComponent<logicmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&birdalive)
        {
            rd.velocity = Vector2.up * flapstrength;
        }
        float verticalspeed = rd.velocity.y;
        float targetAngle = Mathf.Clamp(verticalspeed * 5f,-60f,30f);

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        manager.gameover();
        birdalive = false;
    }
}
