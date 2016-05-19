using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{

	public float Speed = 500;
	public float Gravity = 20;
	public int TouchDamage = 1;

	private Vector2 _direction;
	private Rigidbody2D _rb;

	// Use this for initialization
	void Start () 
	{
		_rb = GetComponent<Rigidbody2D> ();

		if (Random.value > 0.5f)
		{
			_direction = Vector2.right;
		}
		else 
		{
			_direction = Vector2.left;
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector2 movement = Vector2.zero;
		movement = _direction * Time.deltaTime * Speed;
		movement.y -= Gravity*Time.deltaTime;
		_rb.velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//uanset hvad den rammer så skifter den retning
		_direction.x *= -1;

	

	}

	void OnTriggerStay2D(Collider2D other)
	{

		if (other.gameObject.tag == "Player") 
		{
			print ("Kill!!");

			other.gameObject.GetComponent<Health> ().TakeDamage (TouchDamage);

		}

	}



}
