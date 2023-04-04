public interface IIkarusJoystickInput
{
    void OnJoystickMove(string name, float x, float y);
    void OnJoystickUp(string name);
}