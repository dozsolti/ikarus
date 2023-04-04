using System.Collections.Generic;
using SocketIO;
using UnityEngine;

[RequireComponent(typeof(SocketIOComponent))]
public class Ikarus : MonoBehaviour
{
    private SocketIOComponent socket;

    public static List<GameObject> ikarusListeners = new List<GameObject>();

    private static Ikarus ikarusInstance;

    public void Start()
    {
        ikarusListeners = new List<GameObject>();

        socket = gameObject.GetComponent<SocketIOComponent>(); // ws://127.0.0.1:3000/server/?EIO=3&transport=websocket&type=game

        socket.On("input", OnInput);
    }
    private void OnInput(SocketIOEvent e)
    {
        Debug.Log("Oninput" + ikarusListeners.Count);
        string type = e.data["type"].ToString().Replace("\"", "").Trim();
        string eventType = e.data["eventType"].ToString().Replace("\"", "").Trim();
        JSONObject data = e.data["data"];

        InputDTO input = new InputDTO(type, eventType, data);
        foreach (GameObject gameObject in ikarusListeners)
        {
            IIkarusInput proccessor = gameObject.GetComponent<IIkarusInput>();
            string name = input.data["name"].ToString().Replace("\"", "").Trim();

            if (input.type == "joystick")
            {
                if (input.eventType == "up")
                {
                    proccessor.OnJoystickUp(name);
                }
                else
                {
                    proccessor.OnJoystickMove(
                        name,
                        float.Parse(input.data["direction"]["x"].ToString()),
                        float.Parse(input.data["direction"]["y"].ToString())
                    );
                }
            }
            else if (input.type == "button")
            {
                if (input.eventType == "up")
                    proccessor.onButtonUp(name);
                else
                    proccessor.onButtonDown(name);
            }
        }

    }

    public static void AddListener(GameObject newListener)
    {
        ikarusListeners.Add(newListener);
    }
}
