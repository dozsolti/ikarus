using System;
using System.Collections.Generic;
using AOT;
using SocketIO;
using UnityEngine;

public static class Ikarus
{
    public static List<GameObject> ikarusListeners = new List<GameObject>();

    public static void Init()
    {

    }
    
    
    [MonoPInvokeCallback(typeof(Action<SocketIOEvent>))]
    public static void OnInput(SocketIOEvent e)
    {
        string type = e.data["type"].ToString().Replace("\"", "").Trim();
        string eventType = e.data["eventType"].ToString().Replace("\"", "").Trim();
        JSONObject data = e.data["data"];

        InputDTO input = new InputDTO(type, eventType, data);
        foreach (GameObject gameObject in ikarusListeners)
        {
            IIkarusJoystickInput joystickProccessor = gameObject.GetComponent<IIkarusJoystickInput>();
            IIkarusButtonInput buttonProccessor = gameObject.GetComponent<IIkarusButtonInput>();
            string name = input.data["name"].ToString().Replace("\"", "").Trim();

            if (joystickProccessor != null && input.type == "joystick")
            {
                if (input.eventType == "up")
                {
                    joystickProccessor.OnJoystickUp(name);
                }
                else
                {
                    joystickProccessor.OnJoystickMove(
                        name,
                        float.Parse(input.data["direction"]["x"].ToString()),
                        float.Parse(input.data["direction"]["y"].ToString())
                    );
                }
            }

            if (buttonProccessor != null && input.type == "button")
            {
                if (input.eventType == "up")
                    buttonProccessor.onButtonUp(name);
                else
                    buttonProccessor.onButtonDown(name);
            }
        }

    }

    public static void AddListener(GameObject newListener)
    {
        ikarusListeners.Add(newListener);
    }
    public static void CleanUp()
    {
        ikarusListeners.Clear();
    }
}
