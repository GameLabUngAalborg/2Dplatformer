using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float Speed = 100f;
	public int BulletDamage = 1;

	public Vector2 Direction; 

	private Rigidbody2D RB;

	// Use this for initialization
	void Start () 
	{
		RB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		RB.velocity = Direction * Speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		Health tmpCheck = other.GetComponent<Health> ();
		if (tmpCheck != null) 
		{

			// Så har den et health script og vi giver den bulletskade
			tmpCheck.TakeDamage(BulletDamage);
			Destroy (gameObject);

		}
	}
}
