using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    bool restart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        restart = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !restart)
        {
            restart = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
