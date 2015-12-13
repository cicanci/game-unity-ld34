using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour 
{
	public GameObject broccoli;
	public GameObject pizza;

	private Spawner broccoliSpawner;
	private Spawner pizzaSpawner;

	void Start() 
	{
		broccoliSpawner = new Spawner(broccoli);
		pizzaSpawner = new Spawner(pizza);
	}

	public GameObject SpawnFoodRandom()
	{
		GameObject food = null;

		switch (Random.Range(0, 2))
		{
		case 0:
			food = broccoliSpawner.SpawnObject();
			break;
		case 1:
			food = pizzaSpawner.SpawnObject();
			break;
		default:
			food = null;
			break;
		}

		if (food != null) 
		{
			Vector3 pixelPosition = new Vector3(Random.Range(50, Screen.width - 50), Screen.height + 50, 0);
			Vector3 pointPosition = Camera.main.ScreenToWorldPoint(pixelPosition);
			pointPosition.z = 0;

			food.transform.localPosition = pointPosition;
		}

		return food;
	}

}
