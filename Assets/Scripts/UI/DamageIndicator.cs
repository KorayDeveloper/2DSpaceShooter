using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    [SerializeField] private float indicateDuration = 0.5f;

    private SpriteRenderer spriteRend = null;

    void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void Indicate()
    {
        StartCoroutine(FadeOutSprite(spriteRend));
    }

    private IEnumerator FadeOutSprite(SpriteRenderer sprite)
    {
        float elapsed = 0;
        Color startColor = sprite.color;
        startColor.a = 1;
        Color endColor = startColor;
        endColor.a = 0;
        while (elapsed <= 1.0)
        {
            elapsed += Time.deltaTime / indicateDuration;
            sprite.color = Color.Lerp(startColor, endColor, elapsed);
            yield return null;
        }
    }
}
