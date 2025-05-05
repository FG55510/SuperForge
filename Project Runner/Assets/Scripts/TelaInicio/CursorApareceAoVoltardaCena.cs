using UnityEngine;

public class CursorApareceAoVoltardaCena : MonoBehaviour
{

    private void Start()
    {
        ResetCursor();
    }

    public void ResetCursor()
    {
        // Reset to the default system cursor
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
