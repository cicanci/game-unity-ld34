using UnityEngine;

public partial class Character : MonoBehaviour
{
    public float speed;
    public int score;

    private Collider2D other;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTER: " + other.tag);
        this.other = other;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("EXIT: " + other.tag);
        this.other = null;
    }

    public void Attack()
    {
//        Game.instance.PlaySound("Attack1");
//        Game.instance.PlaySound("Attack2");

        if (other != null)
        {
//            Game.instance.PlaySound("Damage");
//            Game.instance.PlaySound("Sink");
//            Game.instance.AddScore(other.gameObject.GetComponent<Character>().score);
            
//            Destroy(other.gameObject);
        }
    }

    public void MoveRight()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + (Time.deltaTime * speed), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }

    public void MoveLeft()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - (Time.deltaTime * speed), gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }
}
