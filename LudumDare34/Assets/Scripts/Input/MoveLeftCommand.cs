using UnityEngine;

public class MoveLeftCommand : Command
{
    public void Execute(GameObject obj)
    {
        obj.GetComponent<Character>().MoveLeft();
    }
}
