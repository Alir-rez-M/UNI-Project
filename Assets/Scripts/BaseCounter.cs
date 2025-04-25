using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour , IKitchenObject
{

    [SerializeField] Transform respawnPoint;
    KitchenObject kitchenObject;
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public virtual void Interact(Player player)
    {




    }
    public virtual void AltInteract(Player player)
    {




    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
    public void CleanKitchenObject()
    {
        kitchenObject = null;
    }
    public virtual Transform GetRespawnPosition()
    {
        return respawnPoint;
    }

}
