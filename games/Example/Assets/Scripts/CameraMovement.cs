using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour, IIkarusInput
{
    bool joystickCameraDown;
    Vector3 cameraRotation;
    public float turnSpeed = 100f;

    void Start()
    {
        Ikarus.AddListener(this.gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (joystickCameraDown)
            transform.RotateAround(transform.position, cameraRotation, turnSpeed * Time.deltaTime);

    }
    public void onButtonDown(string name)
    { }

    public void onButtonUp(string name)
    { }

    /*
        Fiecare object primeste inputul, si proceseaza cum vrea. (Pro: de ex player 1 va putea face ceva daca player 2 se muta, s-au camera/o platforma se poate misca daca playerul se misca) > Fiecare primeste doar informatia necesara ce sa faca. (Gen camera primeste doar cat sa se roteasca)
    */
    public void OnJoystickMove(string name, float x, float y)
    {
        if (name == "camera")
        {
            joystickCameraDown = true;
            cameraRotation = new Vector3(0, x, 0);
        }
    }

    public void OnJoystickUp(string name)
    {
        if (name == "camera")
        {
            joystickCameraDown = false;
        }
    }
}
