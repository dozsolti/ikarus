public interface IIkarusInput
{
    void onButtonDown(string name);
    void onButtonUp(string name);
    void OnJoystickMove(string name, float x, float y);
    void OnJoystickUp(string name);
}