using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private int enemyCount = 1; // Track the number of enemies

    // Call this method when an enemy is destroyed
    public void DeregisterEnemy()
    {
        enemyCount--;
        Debug.Log("Enemy Deregistered. Current count: " + enemyCount);

        // If no enemies are left, change the scene
        if (enemyCount <= 0)
        {
            LoadNextScene();
        }
    }

    // This method handles loading the next scene
    private void LoadNextScene()
    {
        SceneManager.LoadScene("gameover"); // Change to next scene name
    }
}
