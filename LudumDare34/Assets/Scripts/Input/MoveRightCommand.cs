using UnityEngine;

public class MoveRightCommand : Command
{
    public void Execute(GameObject obj)
    {
        obj.GetComponent<Character>().MoveRight();
    }
}
