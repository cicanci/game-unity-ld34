using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour 
{
	public GameObject broccoli;
	public GameObject pizza;

	private Spawner broccoliSpawner;
	private Spawner pizzaSpawner;

	private int broccoliCount;
	private int pizzaCount;

	void Start() 
	{
		broccoliSpawner = new Spawner(broccoli);
		pizzaSpawner = new Spawner(pizza);

		broccoliCount = 0;
		pizzaCount = 0;
	}

	public GameObject SpawnFoodRandom()
	{
		Debug.Log(string.Format("Pizza: {0} Broccoli: {1}", pizzaCount, broccoliCount));

		switch (Random.Range(0, 2))
		{
		case 0:
			broccoliCount++;
			return broccoliSpawner.SpawnObject();
		case 1:
			pizzaCount++;
			return pizzaSpawner.SpawnObject();
		default:
			return null;
		}
	}

}
