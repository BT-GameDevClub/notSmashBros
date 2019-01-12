using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public CharacterController controller;

    public float moveSpeed = 3f;
    public float velX, velY;
    bool facingRight = true;
    Rigidbody2D rigBod;

	// Use this for initialization
	void Start () {
        rigBod = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rigBod.velocity.y;
        rigBod.velocity = new Vector2(velX * moveSpeed, velY);

    }

    // sprite flipping 
    private void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (velX > 0)
        {
            facingRight = true;
        } else if (velX < 0)
        {
            facingRight = false;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

}
