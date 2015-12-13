using UnityEngine;
using System.Collections;

public class Food : Character 
{
	void Update () 
	{
		MoveDown();

		Vector3 pixelPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.localPosition);

		if (pixelPosition.y < 0) 
		{
			Destroy(this.gameObject);
		}
	}
}
