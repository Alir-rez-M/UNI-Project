using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] KitchenObjectSO KitchenObjectSO;
    public event EventHandler containerAnimation;
    public override void Interact(Player player)
    {

        if (!player.HasKitchenObject())
        {
            Transform respawnObject = Instantiate(KitchenObjectSO.kitchenObject);
            respawnObject.transform.GetComponent<KitchenObject>().SetClearCounter(player);
            containerAnimation?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Debug.LogError("It` Not Possible..... ");
        }


    }

}
