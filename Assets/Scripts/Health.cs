using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{

	public int AmountOfHealth = 5;
	public bool InvincibleAfterHit = false;
	public float InvincibleTime = 1f;
	private bool Invincible = false;

	public void TakeDamage(int dmg)
	{

		if (Invincible == false) 
		{
			AmountOfHealth -= dmg;
			if (AmountOfHealth <= 0) 
			{
				Kill ();
			}
			if (InvincibleAfterHit) {
				StartCoroutine (InvincibleTimer ());
			}
		}


	}

	IEnumerator InvincibleTimer()
	{
		Invincible = true;
		print ("Timer");
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		for (float counter = 0; counter < InvincibleTime; counter += Time.deltaTime) 
		{
			if (sr != null) 
			{
				if (sr.enabled) 
				{
					sr.enabled = false;
				} 
				else 
				{
					sr.enabled = true;
				}

			}

			yield return null;
		}
		sr.enabled = true;

		Invincible = false;
	}

	public void Heal(int healing)
	{
		AmountOfHealth += healing;
	}

	void Kill()
	{
		Destroy (gameObject);
	}
}
