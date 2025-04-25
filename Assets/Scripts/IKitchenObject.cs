using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObject
{

    public void SetKitchenObject(KitchenObject kitchenObject);
    public KitchenObject GetKitchenObject();
    public bool HasKitchenObject();
    public void CleanKitchenObject();
    public Transform GetRespawnPosition();
}