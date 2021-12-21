using UnityEngine;

public class RepairKitGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float generatePerSeconds = 10f;

    [Header("References")]
    [SerializeField] private GameObject repairKitPrefab = null;
    [SerializeField] private GameController gameController = null;

    private Vector2 screenWorldPosition;

    private void OnEnable()
    {
        gameController.GameStart += RepeatGeneratePerSeconds;
        gameController.GameOver += StopGenerating;
    }

    private void OnDisable()
    {
        gameController.GameStart -= RepeatGeneratePerSeconds;
        gameController.GameOver -= StopGenerating;
    }

    void Start()
    {
        screenWorldPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void RepeatGeneratePerSeconds()
    {
        InvokeRepeating(nameof(GenerateRepairKit), generatePerSeconds, generatePerSeconds);
    }

    private void StopGenerating()
    {
        CancelInvoke(nameof(GenerateRepairKit));
    }

    private void GenerateRepairKit()
    {
        Vector2 generatePosition;
        generatePosition.x = Random.Range(-screenWorldPosition.x, screenWorldPosition.x);
        generatePosition.y = screenWorldPosition.y + 2;
        Instantiate(repairKitPrefab, generatePosition, Quaternion.identity);
    }
}