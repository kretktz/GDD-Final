using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static float spotCount = 10.00f;

    bool gameHasEnded = false;

    //public float restartDelay = 0.1f;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;

            //Restart the game
            //Invoke("Restart", restartDelay);
            Restart();
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        ResetCounter();
    }

    void ResetCounter()
    {
        spotCount = 10.00f;
    }
}
