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
                player.GetKitchenObject().SetClearCounter(this);    

            }
        }
        else
        {
            if (HasKitchenObject())
            {
                if (player.HasKitchenObject())
                {

                    Debug.Log("Has Object");
                    if (player.GetKitchenObject().TryGetPlateKitchenObject(out PlateKitchenObject plateKitchenObject))
                    {
                        if (plateKitchenObject.TryGetKitchenObjectSO(GetKitchenObject().GetKitchenObjectSO()))
                        {
                            GetKitchenObject().DestroyObject();
                        }
                    }
                    if (GetKitchenObject().TryGetPlateKitchenObject(out plateKitchenObject))
                    {
                        if (plateKitchenObject.TryGetKitchenObjectSO(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroyObject();
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
