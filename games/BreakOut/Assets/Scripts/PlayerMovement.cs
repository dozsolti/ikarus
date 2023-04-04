using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, IIkarusJoystickInput
{
    [SerializeField]
    private float speed;

    bool joystickDown;

    float dirX;

    // Start is called before the first frame update
    void Start()
    {
        Ikarus.AddListener(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (joystickDown)
        {
            transform.position += Vector3.right * dirX * speed * Time.deltaTime;

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -9, 9),
                transform.position.y,
                transform.position.z
            );
        }
    }
    public void OnJoystickMove(string name, float x, float y)
    {
        if (name == "movement")
        {
            joystickDown = true;
            dirX = x;
        }
    }

    public void OnJoystickUp(string name)
    {
        if (name == "movement")
        {
            joystickDown = false;
        }
    }
}
