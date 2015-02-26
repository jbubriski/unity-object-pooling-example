using UnityEngine;
using System.Collections;

public class Player : BaseBehavior
{
	public float FireRate = 1;
	public float FireDelay = 0;
	
	public Transform Bullet;
	
	public Vector3 GunOffset;
	
	public bool UseObjectPool = false;
	
	public float ShipLeadDistanceFromTouch;
	
	public float MovementLerpSpeed = 10;
	
	void Start()
	{
		if (UseObjectPool)
        {
            for (var i = 0; i < 10; i++)
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
					bullet.transform.position = transform.position + GunOffset;
				}
			}
			else
			{
				// New up a bullet everytime
				Instantiate(Bullet, transform.position + GunOffset, Quaternion.identity);
			}
			
			FireDelay = FireRate;
        }
        
		MoveTowardsCursor();
	}
	
	void MoveTowardsCursor()
	{
		var inputPosition = Vector3.one;
		
		if (IsMobile())
		{
			if (Input.touchCount == 0)
				return;
			
			inputPosition = GetInputPosition();
		}
		else
		{
			inputPosition = Input.mousePosition;
		}
		
		inputPosition.z = 150F;
		
		var distance = Camera.main.ScreenToWorldPoint(inputPosition) + new Vector3(0, 0, ShipLeadDistanceFromTouch) - transform.position;
		
		if (distance.magnitude < 1)
			return;
		
		distance.Normalize();
		
		var distanceToMove = distance * Time.deltaTime * MovementLerpSpeed;
		
		transform.position = transform.position + new Vector3(distanceToMove.x, distanceToMove.y, 0);
	}
}
