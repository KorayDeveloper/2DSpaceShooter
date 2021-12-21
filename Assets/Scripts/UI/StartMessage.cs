using UnityEngine;

public class StartMessage : MonoBehaviour
{
    [SerializeField] private GameController gameController = null;

    private VisibilityController visibilityController;

    void Awake()
    {
        visibilityController = GetComponent<VisibilityController>();
    }

    void Start()
    {
        visibilityController.IsFadeInOut = true;
    }

    private void OnEnable()
    {
        gameController.GameStart += visibilityController.StopFadeInOut;
        gameController.GameStart += visibilityController.HideImmediately;
        gameController.GameOver += visibilityController.DoFadeInOut;
    }

    private void OnDisable()
    {
        gameController.GameStart -= visibilityController.StopFadeInOut;
        gameController.GameStart -= visibilityController.HideImmediately;
        gameController.GameOver -= visibilityController.DoFadeInOut;
    }
}