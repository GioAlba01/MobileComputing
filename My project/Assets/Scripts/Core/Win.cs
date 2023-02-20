using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [Header("Win")]
    [SerializeField] private GameObject winScreen;
    [SerializeField] private AudioClip winSound;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            WinGame();
    }

    #region Win
    public void WinGame()
    {
        winScreen.SetActive(true);
        SoundManager.instance.PlaySound(winSound);
    }

    #endregion
}
