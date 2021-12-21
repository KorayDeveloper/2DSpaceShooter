using UnityEngine;

public class GameOverMessage : MonoBehaviour
{
    [SerializeField] private GameController gameController = null;

    private VisibilityController visibilityController;

    void Awake()
    {
        visibilityController = GetComponent<VisibilityController>();
    }

    private void OnEnable()
    {
        gameController.GameStart += HideIfVisible;
        gameController.GameOver += visibilityController.Show;
    }

    private void OnDisable()
    {
        gameController.GameStart -= HideIfVisible;
        gameController.GameOver -= visibilityController.Show;
    }

    private void HideIfVisible()
    {
        if (visibilityController.IsVisible)
            visibilityController.HideImmediately();
    }
}