using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	private float _lifeTimer = 2.5F;
	
	public bool UseObjectPool;
	public float Speed = 1;
	
	void Start()
	{
		Sphere.Current.Increment();
	}
	
	void Awake()
	{
		_lifeTimer = 2.5F;
	}
	
	void Update()
	{
		transform.position = transform.position + (Vector3.up * Speed * Time.deltaTime);
		
		_lifeTimer -= Time.deltaTime;
		
		if (_lifeTimer <= 0)
		{
			Destroy();
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision2D)
	{
		if (UseObjectPool)
		{
			gameObject.SetActive(false);
		}
		else
		{
			Destroy();
		}
	}
	
	void Destroy()
	{
		Destroy(gameObject);
		
		Sphere.Current.Decrement();
	}
}
