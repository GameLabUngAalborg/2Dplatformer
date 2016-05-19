using UnityEngine;
using System.Collections;

public class ShootWeapon : MonoBehaviour {

	public GameObject PrefabBullet;
	public GameObject BulletSpawnPoint;
	public float ReloadTime = 1f;
	public int MagazineSize = 5;

	private float CurrentAmmo;
	private float reloadCounter = 0;

	// Use this for initialization
	void Start () {

		CurrentAmmo = MagazineSize;
	
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.K) && CurrentAmmo > 0) 
		{
			CurrentAmmo--;
			GameObject tmp = Instantiate (PrefabBullet) as GameObject;
			tmp.transform.position = BulletSpawnPoint.transform.position;

			// tjek om den er til venstre eller højre for spiller
			if (tmp.transform.position.x > transform.position.x) {
				// Så er den til højre
				tmp.GetComponent<Bullet>().Direction = Vector2.right;
			} 
			else 
			{
				tmp.GetComponent<Bullet> ().Direction = Vector2.left;
			}


			// Sætter den til at ødelægge sig selv efter x sekunder så vi ikke har en masse skud i scenen.
			Destroy(tmp, 2);

		}

		if (CurrentAmmo <= 0) 
		{
			reloadCounter += Time.deltaTime;
			if (reloadCounter >= ReloadTime) 
			{
				CurrentAmmo = MagazineSize;
				reloadCounter = 0;

			}


		}
	
	}
}
