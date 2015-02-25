using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float FireRate = 1;
	public float FireDelay = 0;
	
	public Transform Bullet;
	
	public bool UseObjectPool = false;
	
	void Start()
	{
		if (UseObjectPool)
        {
            for (var i = 0; i < 20; i++)
			{
				var bullet = (Transform)Instantiate(Bullet);
				
				bullet.gameObject.SetActive(false);
				bullet.GetComponent<Bullet>().UseObjectPool = true;
				
				ObjectPool.AddBullet(bullet.GetComponent<Bullet>());
			}
		}
	}
	
	void Update()
	{
		FireDelay -= Time.deltaTime;
		
		if (Input.GetButton("Fire1") && FireDelay <= 0)
		{
			if (UseObjectPool)
			{
				var bullet = ObjectPool.GetBullet();
				
				if (bullet != null)
				{
					bullet.transform.position = transform.position;
				}
			}
			else
			{
				// New up a bullet everytime
				Instantiate(Bullet, transform.position, Quaternion.identity);
			}
			
			FireDelay = FireRate;
        }
	}
}
