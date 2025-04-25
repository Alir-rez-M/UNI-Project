using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour 
{
    [SerializeField] GameObject hasPorgressBar;
    [SerializeField] Image image;
    IProgressBar progressBar;
    private void Start()
    {
        progressBar = hasPorgressBar.GetComponent<IProgressBar>();
        if (progressBar == null)
        {
            Debug.Log("Null");
        }
        progressBar.OnProgressBar += CuttingCounter_OnProgressBar;
        Hide();
    }

    private void CuttingCounter_OnProgressBar(object sender, IProgressBar.OnProgressBarEventArgs e)
    {
        image.fillAmount = e.progress;
        if(e.progress == 0 || e.progress >= 1)
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
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
}
