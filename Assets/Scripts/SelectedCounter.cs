using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField] BaseCounter baseCounter;
    [SerializeField] GameObject[] selectedVisuals;
    void Start()
    {
        Player.Instance.OnSelectedCounter += Instance_OnSelectedCounter;
    }

    private void Instance_OnSelectedCounter(object sender, Player.OnSelectedCounterEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        foreach (GameObject visual in selectedVisuals)
        {
            visual.SetActive(false);
        }
    }
    private void Show()
    {
        foreach (GameObject visual in selectedVisuals)
        {
            visual.SetActive(true);
        }
    }
}
