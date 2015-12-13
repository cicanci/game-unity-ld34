using UnityEngine;

public partial class Character : MonoBehaviour
{
    public float speed;
    public int score;
	public bool enableRotation;

    public void MoveRight()
    {
		if (enableRotation) 
		{
			gameObject.transform.Rotate(Vector3.forward * -speed);
		}
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + (Time.deltaTime * speed), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }

    public void MoveLeft()
    {
		if (enableRotation) 
		{
			gameObject.transform.Rotate(Vector3.forward * speed);
		}
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - (Time.deltaTime * speed), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }

	public void MoveUp()
	{
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + (Time.deltaTime * speed), gameObject.transform.localPosition.z);
	}

	public void MoveDown()
	{
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - (Time.deltaTime * speed), gameObject.transform.localPosition.z);
	}
}
