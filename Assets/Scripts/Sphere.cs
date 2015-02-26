using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour
{
	private static Sphere _sphere;
	
	public static Sphere Current
	{
		get
		{
			return _sphere;
		}
	}
	
	private int _counter = 1;
	
	void Start()
	{
		_sphere = GameObject.Find("Sphere").GetComponent<Sphere>();
	}
	
	void Update ()
	{
		transform.localScale = new Vector3(_counter, _counter, _counter);
	}
	
	public void Increment()
	{
		_counter++;
	}
	
	public void Decrement()
	{
		_counter--;
	}
}
