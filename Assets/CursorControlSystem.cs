using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControlSystem : MonoBehaviour
{

    float _x;
    float _y;

    // Update is called once per frame
    void Update()
    {
        CheckJoystickInput();
    }
    void CheckJoystickInput()
    {
        _x = Input.GetAxis("JoystickMouseX");
        _y = Input.GetAxis("JoystickMouseY");

        if (_x > 0.02 || _x < -0.02 || _y > 0.02 || _y < -0.02)
        {
            float cursorX = CursorControl.GetGlobalCursorPos().x;
            float cursorY = CursorControl.GetGlobalCursorPos().y;
            float newX = cursorX - ((cursorX * _x) / 4);
            float newY = cursorY - ((cursorY * _y) / 4);
            Vector2 newCursorPos = new Vector2(newX, newY);
            CursorControl.SetGlobalCursorPos(newCursorPos);
        }

    }
}
