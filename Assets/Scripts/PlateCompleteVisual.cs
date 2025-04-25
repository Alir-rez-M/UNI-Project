using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [Serializable] private struct ManageCompleteVisual
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject completePlateVisual;
    }
    [SerializeField] private List<ManageCompleteVisual> manageCompleteVisualList;
    private void Start()
    {
        plateKitchenObject.OnCompletePlateVisual += PlateKitchenObject_OnCompletePlateVisual;
        foreach (ManageCompleteVisual plateVisuals in manageCompleteVisualList)
        {
            
                plateVisuals.completePlateVisual.SetActive(false);
            
        }
    }

    private void PlateKitchenObject_OnCompletePlateVisual(object sender, PlateKitchenObject.OnCompletePlateVisualEventArgs e)
    {
        foreach (ManageCompleteVisual plateVisuals in manageCompleteVisualList)
        {
            if (e.kitchenObjectSO == plateVisuals.kitchenObjectSO)
            {
                plateVisuals.completePlateVisual.SetActive(true);
            }
        }
    }
}
