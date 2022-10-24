using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    public bool CanLaunch;

    public RectTransform OutSide;

    public RectTransform Knob;

    public float JoystickRange;

    public bool FixedJoystick;

    [HideInInspector]
    public Vector2 Direction;

    public bool Moved = false;
private void Start() {
    CanLaunch=true;
}
    void ShowHide(bool state)
    {
        OutSide.gameObject.SetActive (state);
        Knob.gameObject.SetActive (state);
    }

    void Joystick()
    {
        if (CanLaunch == true)
        {
            Vector2 pos = Input.mousePosition;
            if (
                Input.GetMouseButtonDown(0) //For being active joystick when finger on screen.
            )
            {
                OutSide.position = pos;
                Knob.position = pos;
                ShowHide(true);
                Moved = true;
            }
            else if (
                Input.GetMouseButton(0) //For move player with joystick.
            )
            {
                Knob.position = pos;
                Knob.position =
                    OutSide.position +
                    Vector3
                        .ClampMagnitude(Knob.position - OutSide.position,
                        OutSide.sizeDelta.x * JoystickRange);
                if (
                    Knob.position != Input.mousePosition && !FixedJoystick //Fixed Part
                )
                {
                    Vector3 outsideBoundsVector =
                        Input.mousePosition - Knob.position;
                    OutSide.position += outsideBoundsVector;
                }
                Direction = (Knob.position - OutSide.position).normalized;
            }
            else
            {
                Moved = false;
                Direction = Vector2.zero;
                ShowHide(false);
            }
        }
    }

    private void Update()
    {
        Joystick();
    }
}
