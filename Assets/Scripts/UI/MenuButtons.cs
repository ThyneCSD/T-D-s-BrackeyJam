using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void PlayClick()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("pluhlpullh");
    }
    public void QuitClick()
    {
        Application.Quit();
        Debug.Log("pluhlpquihgnpl");
    }
}
