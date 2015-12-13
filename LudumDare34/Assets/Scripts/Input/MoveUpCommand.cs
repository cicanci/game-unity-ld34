using UnityEngine;

public class MoveUpCommand : Command
{
    public void Execute(GameObject obj)
    {
        obj.GetComponent<Character>().MoveUp();
    }
}
