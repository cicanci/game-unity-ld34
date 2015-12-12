using UnityEngine;

public class Spock : Character
{
    void LateUpdate()
    {
        float left = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float right = Camera.main.ViewportToWorldPoint(Vector3.one).x;
        float top = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
        float bottom = Camera.main.ViewportToWorldPoint(Vector3.one).y;

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
        else if (gameObject.transform.position.y >= bottom - gameObject.GetComponent<Renderer>().bounds.extents.y)
        {
            y = bottom - gameObject.GetComponent<Renderer>().bounds.extents.y;
        }

        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
