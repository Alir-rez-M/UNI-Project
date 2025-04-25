using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingVisual : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private GameObject[] cookingVisuals;
    private void Start()
    {
        stoveCounter.OnCookingVisual += StoveCounter_OnCookingVisual;
    }

    private void StoveCounter_OnCookingVisual(object sender, StoveCounter.OnCookingVisualEventArgs e)
    {
        if (e.state == StoveCounter.CookState.Idle || e.state == StoveCounter.CookState.End)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
    private void Hide()
    {
        foreach (GameObject visual in cookingVisuals)
        {
            visual.SetActive(false);
        }
    }
    private void Show()
    {
        foreach (GameObject visual in cookingVisuals)
        {
            visual.SetActive(true);
        }
    }
}
