using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    private List<KitchenObjectSO> kitchenObjectSOList;
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSO;
    public event EventHandler<OnCompletePlateVisualEventArgs> OnCompletePlateVisual;
    public class OnCompletePlateVisualEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }
    private void Start()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    public bool TryGetKitchenObjectSO(KitchenObjectSO kitchenObjectSO)
    {
        if (!validKitchenObjectSO.Contains(kitchenObjectSO))
        {
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO)) 
        {
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);
            OnCompletePlateVisual?.Invoke(this, new OnCompletePlateVisualEventArgs()
            {
                kitchenObjectSO = kitchenObjectSO,
            });
            return true;
        }
    }
    public List<KitchenObjectSO> GetKitcchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
