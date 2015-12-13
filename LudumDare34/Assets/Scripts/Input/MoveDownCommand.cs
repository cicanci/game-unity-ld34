using UnityEngine;

public class MoveDownCommand : Command
{
    public void Execute(GameObject obj)
    {
        obj.GetComponent<Character>().MoveDown();
    }
}
