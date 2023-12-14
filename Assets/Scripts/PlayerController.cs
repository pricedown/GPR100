using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float acceleration = 290f;
	public float maxSpeed = 25f;
	
	// The drag constant is (Cd*p*A)/m
	// Cd = drag coefficient
	// p = air density
	// A = cross-sectional area of the object
	// m = mass of the object
	public float dragConstant = 1.76f;
	
	private Rigidbody2D rb;
	
	private Vector2 _wishdir = new Vector2();
	private Vector2 _dragaccel = new Vector2();
	private Vector2 _accel = new Vector2();

	private float speed;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
		rb.drag = 0;
		rb.angularDrag = 0;
	}

    void Update() {
	    _wishdir.x = Input.GetAxisRaw("Horizontal");
	    _wishdir.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
	    // NOTE: Acceleration physics is based on non-rotating objects
	    _dragaccel = -0.5f * dragConstant * (rb.velocity * rb.velocity.magnitude);
	    _accel = _wishdir * acceleration + _dragaccel;
	    
	    rb.velocity += Vector2.ClampMagnitude(_accel * Time.fixedDeltaTime, maxSpeed);
    }
}
