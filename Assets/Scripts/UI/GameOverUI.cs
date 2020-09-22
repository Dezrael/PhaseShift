using UnityEngine;
using UnityEngine.Events;

public class GameOverUI : MonoBehaviour
{
    public UnityEvent restartGame = new UnityEvent();
    public UnityEvent mainMenu = new UnityEvent();
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        panel.SetActive(false);
    }

    public void Activate()
    {
        panel.SetActive(true);
    }

    public void RestartGame()
    {
        restartGame?.Invoke();
    }

    public void MainMenu()
    {
        mainMenu?.Invoke();
    }
}
