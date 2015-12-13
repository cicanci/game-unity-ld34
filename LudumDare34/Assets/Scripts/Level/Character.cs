using UnityEngine;

public partial class Character : MonoBehaviour
{
    public float speed;
    public int score;

    public void MoveRight()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + (Time.deltaTime * speed), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }

    public void MoveLeft()
    {
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
