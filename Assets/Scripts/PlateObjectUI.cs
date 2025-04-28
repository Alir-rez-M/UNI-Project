using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateObjectUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject kitchenObject;
    [SerializeField] private Transform plateIconUI;

    private void Start()
    {
        kitchenObject.OnCompletePlateVisual += KitchenObject_OnCompletePlateVisual;
    }
    private void Awake()
    {
        plateIconUI.gameObject.SetActive(false);


    }
    

    private void KitchenObject_OnCompletePlateVisual(object sender, PlateKitchenObject.OnCompletePlateVisualEventArgs e)
    {
        foreach (Transform child in transform)
        {
            if (child == plateIconUI) continue;
            Destroy(child.gameObject);
        }
        foreach (KitchenObjectSO kitchenObjectSO in kitchenObject.GetKitcchenObjectSOList())
        {
            Transform plateIconUITransform = Instantiate(plateIconUI, transform);
            plateIconUITransform.gameObject.SetActive(true);
            plateIconUITransform.transform.GetComponent<PlateIconUI>().SetKitchenObjectSO(kitchenObjectSO);
            
        }
    }
}
