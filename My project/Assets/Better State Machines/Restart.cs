using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    void Update()
    {
        if (gameObject.transform.position.y <= -30)
        {
            SceneManager.LoadScene("gameover");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}      