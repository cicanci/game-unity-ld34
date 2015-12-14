using UnityEngine;

public class Spock : Character
{
	public float speedIncrement;
	public float scaleIncrement;
	public float minSpeed;

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("ENTER: " + other.tag);

		Food food = other.gameObject.GetComponent<Food>();

		if (food.isGood)
		{
			Game.instance.AddScore(food.score);
		}
		else 
		{
			Vector3 newScale = new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
			gameObject.transform.localScale += newScale;

			Sprite sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
			Vector2 spriteSize = new Vector2(sprite.bounds.size.x * sprite.pixelsPerUnit * gameObject.transform.localScale.x, 
				sprite.bounds.size.y * sprite.pixelsPerUnit * gameObject.transform.localScale.y);

			if (spriteSize.x > Screen.width * 0.9f)
			{
				Game.instance.ShowMessage("Too big! Game Over!", Color.red);
				Game.instance.GameOver();
			}
			else if (spriteSize.x > Screen.width * 0.3f)
			{
				Game.instance.ShowMessage("He is growing...", Color.yellow);
				enableRotation = true;
			}
			else 
			{
				Game.instance.ShowMessage("Still healthy", Color.black);
			}

			if (speed > minSpeed) 
			{
				speed -= speedIncrement;
			}
		}

		Destroy(other.gameObject);
	}

    void LateUpdate()
    {
        float left = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float right = Camera.main.ViewportToWorldPoint(Vector3.one).x;
        float top = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
//        float bottom = Camera.main.ViewportToWorldPoint(Vector3.one).y;

        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;

        if (gameObject.transform.position.x <= left + gameObject.GetComponent<Renderer>().bounds.extents.x)
        {
            x = left + gameObject.GetComponent<Renderer>().bounds.extents.x;
        }
        else if (gameObject.transform.position.x >= right - gameObject.GetComponent<Renderer>().bounds.extents.x)
        {
            x = right - gameObject.GetComponent<Renderer>().bounds.extents.x;
        }

        if (gameObject.transform.position.y <= top + gameObject.GetComponent<Renderer>().bounds.extents.y)
        {
            y = top + gameObject.GetComponent<Renderer>().bounds.extents.y;
        }
//        else if (gameObject.transform.position.y >= bottom - gameObject.GetComponent<Renderer>().bounds.extents.y)
//        {
//            y = bottom - gameObject.GetComponent<Renderer>().bounds.extents.y;
//        }

        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
