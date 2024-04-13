using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void QuitGame(){
        // Check if the application is running in the Unity Editor
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
