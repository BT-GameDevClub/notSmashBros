using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public CharacterController controller;

    public float moveSpeedX = 3;
    public float moveSpeedY = 2;
    public float velX, velY;
    bool facingRight = true;
    Rigidbody2D rigBod;

	// Use this for initialization
	void Start () {
        rigBod = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rigBod.velocity.y;

        if (Physics2D.Raycast(transform.position, -transform.up, 0.53f))
        {
            Debug.Log(rigBod.velocity.y);
            velY = Input.GetAxisRaw("Vertical") * moveSpeedY;
        }

        rigBod.velocity = new Vector2(velX * moveSpeedX, velY);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.up);
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
