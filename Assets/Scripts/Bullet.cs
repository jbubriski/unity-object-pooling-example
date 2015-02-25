using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public bool UseObjectPool;
	public float Speed = 1;
	
	void Start()
	{
		
	}
	
	void Update()
	{
		transform.position = transform.position + (Vector3.up * Speed * Time.deltaTime);
	}
	
	void OnCollisionEnter2D(Collision2D collision2D)
	{
		if (UseObjectPool)
		{
			gameObject.SetActive(false);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
