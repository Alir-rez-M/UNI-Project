using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroyObject();  
        }
        else
        {
            Debug.Log("You Do Not Have Trash");
        }
    }
}
