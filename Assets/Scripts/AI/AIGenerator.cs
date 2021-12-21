using UnityEngine;

public class AIGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float generateAPerSeconds = 2f;
    [SerializeField] private float generateBPerSeconds = 10f;
    [SerializeField] private float generateCPerSeconds = 5f;

    [Header("References")]
    [SerializeField] private GameObject aiAircraftAPrefab = null;
    [SerializeField] private GameObject aiAircraftBPrefab = null;
    [SerializeField] private GameObject aiAircraftCPrefab = null;
    [SerializeField] private GameController gameController = null;
    [SerializeField] private AITargetController targetController = null;

    private Vector2 screenWorldPosition;

    private void OnEnable()
    {
        gameController.GameStart += RepeatGeneratingAPerSeconds;
        gameController.GameStart += RepeatGeneratingBPerSeconds;
        gameController.GameStart += RepeatGeneratingCPerSeconds;
        gameController.GameOver += StopGenerating;
    }

    private void OnDisable()
    {
        gameController.GameStart -= RepeatGeneratingAPerSeconds;
        gameController.GameStart -= RepeatGeneratingBPerSeconds;
        gameController.GameStart -= RepeatGeneratingCPerSeconds;
        gameController.GameOver -= StopGenerating;
    }

    void Start()
    {
        screenWorldPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void RepeatGeneratingAPerSeconds()
    {
        InvokeRepeating(nameof(GenerateAIAircraftA), generateAPerSeconds, generateAPerSeconds);
    }

    private void RepeatGeneratingBPerSeconds()
    {
        InvokeRepeating(nameof(GenerateAIAircraftB), generateBPerSeconds, generateBPerSeconds);
    }

    private void RepeatGeneratingCPerSeconds()
    {
        InvokeRepeating(nameof(GenerateAIAircraftC), generateCPerSeconds, generateCPerSeconds);
    }

    private void StopGenerating()
    {
        CancelInvoke(nameof(GenerateAIAircraftA));
        CancelInvoke(nameof(GenerateAIAircraftB));
        CancelInvoke(nameof(GenerateAIAircraftC));
    }

    private void GenerateAIAircraftA()
    {
        Vector2 generatePosition;
        generatePosition.x = Random.Range(-screenWorldPosition.x, screenWorldPosition.x);
        generatePosition.y = screenWorldPosition.y + 2;
        GameObject aiAircraft = Instantiate(aiAircraftAPrefab, generatePosition, Quaternion.Euler(0, 0, 180));
        aiAircraft.GetComponent<AIController>().SetTargetController(targetController);
    }

    private void GenerateAIAircraftB()
    {
        Vector2 generatePosition;
        generatePosition.x = Random.Range(-screenWorldPosition.x, screenWorldPosition.x);
        generatePosition.y = screenWorldPosition.y + 2;
        GameObject aiAircraft = Instantiate(aiAircraftBPrefab, generatePosition, Quaternion.Euler(0, 0, 180));
        aiAircraft.GetComponent<AIController>().SetTargetController(targetController);
    }

    private void GenerateAIAircraftC()
    {
        Vector2 generatePosition;
        generatePosition.x = Random.Range(-screenWorldPosition.x, screenWorldPosition.x);
        generatePosition.y = screenWorldPosition.y + 2;
        GameObject aiAircraft = Instantiate(aiAircraftCPrefab, generatePosition, Quaternion.Euler(0, 0, 180));
        aiAircraft.GetComponent<AIController>().SetTargetController(targetController);
    }
}