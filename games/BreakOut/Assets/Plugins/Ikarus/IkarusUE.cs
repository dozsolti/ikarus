using SocketIO;
using UnityEngine;

[RequireComponent(typeof(SocketIOComponent))]
public class IkarusUE : MonoBehaviour
{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
    private SocketIOComponent socket;

    void Start()
    {
        socket = gameObject.GetComponent<SocketIOComponent>();

        socket.On("input", Ikarus.OnInput);
        Debug.Log("hello from IkarusUE.cs");
        Ikarus.Init();
    }

    private void OnDestroy()
    {
        Ikarus.CleanUp();
    }
#endif
}
