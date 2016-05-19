using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject EnemyPrefab;
	public float SpawnSpeed = 5;
	public int EnemyHealth = 1;
	public GameObject SpawnLocation;

	private int EnemyCounter = 0;

	// Use this for initialization
	IEnumerator Start ()
	{
		while (true) 
		{
			yield return new WaitForSeconds (SpawnSpeed);

			if (EnemyCounter == 5)
			{
				EnemyHealth = 7;
				SpawnSpeed = 3;
			}
		
				GameObject spawn = Instantiate (EnemyPrefab) as GameObject;
				spawn.transform.position = SpawnLocation.transform.position;
				spawn.GetComponent<Health> ().AmountOfHealth = EnemyHealth;
		

		


			EnemyCounter++;

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
