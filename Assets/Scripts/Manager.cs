using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //bool gameHasEnded = false;

    public float restartDelay = 1f;
    public void EndGame()
    {
        //if(gameHasEnded == false)
        //{
            //gameHasEnded = true;
            //Debug.Log("Game over");

            //Restart the game
            //Invoke("Restart", restartDelay);
        //}
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
