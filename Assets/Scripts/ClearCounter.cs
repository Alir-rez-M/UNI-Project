using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (!HasKitchenObject())
                {
                    player.GetKitchenObject().SetClearCounter(this);
                }

            }
        }
        else
        {
            if (HasKitchenObject())
            {
                if (player.HasKitchenObject())
                {

                    Debug.Log("Has Object");
                    if (player.GetKitchenObject() is PlateKitchenObject)
                    {
                        PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                        if (plateKitchenObject.TryGetKitchenObjectSO(GetKitchenObject().GetKitchenObjectSO()))
                        {
                            GetKitchenObject().DestroyObject();
                        }
                    }
                }
                else
                {
                    GetKitchenObject().SetClearCounter(player);
                }
            }
            
        }
        
        
    }
    
}
