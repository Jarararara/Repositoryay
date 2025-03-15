using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Update is called once per frame
    public void RestartButton()
    {
        SceneManager.LoadScene("Level");
    }
}
