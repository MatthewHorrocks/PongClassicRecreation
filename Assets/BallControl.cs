using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallControl : MonoBehaviour
{
	public static BallControl instance; 
	private Vector2 dir;

	private Collider2D pastCollider;

	private Vector3 startingPos;
	
	[SerializeField] private float ballRadius;
	private float speed;
	
	[SerializeField] private float speedIncPerSecond;
	[SerializeField] private float startingSpeed;

	private void Awake()
	{
		dir = new Vector3(Random.value > 0.5 ? 1 : -1, 0, 0);
		startingPos = transform.position;
		instance = this;
		reset();
	}

	private void Update()
	{
		increaseBallSpeed();
		moveBall();
	}

	private void moveBall()
	{
		var movement = ((Vector3) dir * speed * Time.deltaTime);
		checkForCollision(movement);
		transform.position += movement;
	}

	private void increaseBallSpeed()
	{
		speed += speedIncPerSecond * Time.deltaTime;
	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(transform.position,ballRadius);
	}

	public bool checkColliders(Collider2D collider)
	{

		if (collider == pastCollider)
			return false;
		
		if (collider == null)
			return false;
		
		var segment = collider.transform.GetComponent<Segment>();
		if (segment == null)
			return false;
		
		dir = segment.getDirection(dir);
		
		pastCollider = collider;
		
		return true;
	}
	
	private void checkForCollision(Vector3 movement)
	{
		RaycastHit2D hit2D = Physics2D.Raycast(transform.position, movement, movement.magnitude + ballRadius);
		if (checkColliders(hit2D.collider))
			return;
		
		var hit2Dd = Physics2D.OverlapCircle(transform.position, ballRadius /2);
		if (hit2Dd != null)
		Debug.Log(hit2Dd.transform.name);
		checkColliders(hit2Dd);
		

	}
	
	public static Vector2 GetDirectionFromAngle( float degrees )
	{
		return new Vector2( Mathf.Sin( Mathf.Deg2Rad * degrees ), Mathf.Cos( Mathf.Deg2Rad * degrees ) );
	}
	
	
	public void reset()
	{
		transform.position = startingPos;
		speed = startingSpeed;
	}

}