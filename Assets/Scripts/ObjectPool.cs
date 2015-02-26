using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool
{
	static List<Bullet> _pool = new List<Bullet>();
	
	public static void AddBullet(Bullet bullet)
	{
		_pool.Add(bullet);
	}
	
    public static Bullet GetBullet()
    {
    	foreach (var bullet in _pool)
    	{
			if (!bullet.gameObject.activeSelf)
    		{
				bullet.gameObject.SetActive(true);
				
    			return bullet;
			}
    	}
    	
    	return null;
    }
}
