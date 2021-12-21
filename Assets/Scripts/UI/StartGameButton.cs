using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private float waitBeforeActivateTime = 2f;
    [SerializeField] private GameController gameController = null;

    private Image image;
    private Button button;

    void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        gameController.GameStart += Deactivate;
        gameController.GameOver += ActivateAfterWait;
    }

    private void OnDisable()
    {
        gameController.GameStart -= Deactivate;
        gameController.GameOver -= ActivateAfterWait;
    }

    private void ActivateAfterWait()
    {
        Invoke(nameof(Activate), waitBeforeActivateTime);
    }

    private void Activate()
    {
        image.enabled = true;
        button.enabled = true;
    }

    private void Deactivate()
    {
        image.enabled = false;
        button.enabled = false;
    }
}