﻿using UnityEngine;
using System.Collections;

public class Food : Character 
{
	public bool isGood;

	void Update () 
	{
		MoveDown();

		Vector3 pixelPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.localPosition);

		if (pixelPosition.y < -50) 
		{
			Destroy(this.gameObject);
		}
	}
}
