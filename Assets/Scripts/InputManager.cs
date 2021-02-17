using UnityEngine;

public class InputManager
{
    public KeyCode GetInput()
    {
        return Input.GetKeyDown(KeyCode.A) ? KeyCode.A :
            Input.GetKeyDown(KeyCode.D) ? KeyCode.D :
            Input.GetKeyDown(KeyCode.S) ? KeyCode.S :
            Input.GetKeyDown(KeyCode.W) ? KeyCode.W : KeyCode.None;
    }
}
