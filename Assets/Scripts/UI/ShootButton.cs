using UnityEngine;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour
{
    [SerializeField] private GameController gameController = null;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        gameController.GameStart += Activate;
        gameController.GameOver += Deactivate;
    }

    private void OnDisable()
    {
        gameController.GameStart -= Activate;
        gameController.GameOver -= Deactivate;
    }

    private void Activate()
    {
        button.interactable = true;
    }

    private void Deactivate()
    {
        button.interactable = false;
    }
}