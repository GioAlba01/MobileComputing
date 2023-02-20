using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel2 : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level3", 6));
    }
}
