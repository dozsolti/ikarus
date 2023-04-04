using System.Runtime.InteropServices;
using SocketIO;
using UnityEngine;
using Newtonsoft.Json;
using AOT;
using System;

public class IkarusWebGL : MonoBehaviour
{

    void Start(){
        string data = keyValueToString("type", "joystick");
        InputDTO input = JsonConvert.DeserializeObject<InputDTO>(data);
        Debug.Log(input.type.ToString());
    }

    string keyValueToString(string key, string value){
        return "{\"type\":\"joystick\"}";
    }
/* #if UNITY_WEBGL && !UN
    [DllImport("__Internal")]
    private static extern void Connect(Action<IntPtr> callback);
    [DllImport("__Internal")]
    private static extern void Clo(string message);

    void Start()
    {
        Debug.Log("hell from webGL");
        Connect(OnInput);
        Ikarus.Init();
    }
    [MonoPInvokeCallback(typeof(Action))]
    private static void OnInput(IntPtr dataPointer)
    {
        string data = Marshal.PtrToStringAuto(dataPointer);
        Debug.Log(data);
        SocketIO.SocketIOEvent input = JsonConvert.DeserializeObject<SocketIO.SocketIOEvent>(data);
        Ikarus.OnInput(input);
    }
    void OnDestroy()
    {
        // Ikarus.CleanUp();
    }
#endif */
}
