using System;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CanvasGroup))]
public class VisibilityController : MonoBehaviour
{
    public event Action Visible;
    public event Action Invisible;
    private bool isVisible;
    public bool IsVisible => isVisible;
    private bool isFadeInOut;
    public bool IsFadeInOut
    {
        get => isFadeInOut;
        set
        {
            isFadeInOut = value;
            animator.SetBool("IsFadeInOut", value);
        }
    }

    private Animator animator;
    private CanvasGroup cg;

    void Awake()
    {
        animator = GetComponent<Animator>();
        cg = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        animator.SetTrigger("Show");
    }

    public void ShowImmediately()
    {
        animator.SetTrigger("ShowImmediately");
    }

    public void Hide()
    {
        animator.SetTrigger("Hide");
    }

    public void HideImmediately()
    {
        animator.SetTrigger("HideImmediately");
    }

    public void DoFadeInOut()
    {
        IsFadeInOut = true;
    }

    public void StopFadeInOut()
    {
        IsFadeInOut = false;
    }

    public void OnVisible()
    {
        isVisible = true;
        if (Visible != null)
            Visible.Invoke();
    }

    public void OnInvisible()
    {
        isVisible = false;
        if (Invisible != null)
            Invisible.Invoke();
    }
}