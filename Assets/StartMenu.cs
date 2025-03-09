using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets
{
	public class StartMenu : MonoBehaviour
	{
		public void StartGame()
		{
            Debug.Log("Start button clicked!");
            SceneManager.LoadScene(1);
			Debug.Log("Main Game loaded");
		}
		public void QuitGame()
		{
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Unity editor
#endif
        }
    }
}