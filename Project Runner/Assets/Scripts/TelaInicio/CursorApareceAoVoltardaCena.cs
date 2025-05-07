using UnityEngine;

public class CursorApareceAoVoltardaCena : MonoBehaviour
{

    private void Start()
    {
        ResetCursor();
    }

    public void ResetCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
