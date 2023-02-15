using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private RectTransform arrow;
    [SerializeField] private RectTransform[] buttons;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;
    private int currentPosition;

    private void Awake()
    {
        ChangePosition(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Submit"))
            Interact();
    }

    public void ChangePosition(int _change)
    {
        currentPosition += _change;

        if (_change != 0)
            SoundManager.instance.PlaySound(changeSound);

        if (currentPosition < 0)
            currentPosition = buttons.Length - 1;
        else if (currentPosition > buttons.Length - 1)
            currentPosition = 0;

        AssignPosition();
    }
    private void AssignPosition()
    {
        arrow.position = new Vector3(arrow.position.x, buttons[currentPosition].position.y);
    }
    public void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);

        if (currentPosition == 0)
        {
            //Start game
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level1", 1));
        }
        else if (currentPosition == 1)
        {
            //Open Settings
            SceneManager.LoadScene(PlayerPrefs.GetInt("Settings", 3));
        }
        else if (currentPosition == 2)
        {
            //Open Credits
        }
        else if (currentPosition == 3)
            Application.Quit();
    }

    #region Settings
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("_MainMenu", 0));
    }
    #endregion
}
