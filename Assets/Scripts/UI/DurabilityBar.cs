using UnityEngine;
using UnityEngine.UI;

public class DurabilityBar : MonoBehaviour
{
    private int value;
    public int Value
    {
        get => value;
        set
        {
            this.value = value;
            image.fillAmount = Mathf.Lerp(0, 1, Mathf.InverseLerp(0, MaxValue, value));
        }
    }

    public int MaxValue { get; set; }

    [SerializeField] private Image image = null;
    [SerializeField] private GameController gameController = null;

    private VisibilityController visibilityController;

    void Awake()
    {
        visibilityController = GetComponent<VisibilityController>();
    }

    private void OnEnable()
    {
        gameController.GameStart += visibilityController.Show;
    }

    private void OnDisable()
    {
        gameController.GameStart -= visibilityController.Show;
    }
}