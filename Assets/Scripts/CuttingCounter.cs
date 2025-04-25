using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CuttingCounter : BaseCounter , IProgressBar
{
    // Start is called before the first frame update

    [SerializeField] SlicedObjects[] slicedObjects;
    private int cuttingMax;
    public event EventHandler OnCutAnimations;
    public event EventHandler<IProgressBar.OnProgressBarEventArgs> OnProgressBar;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetClearCounter(this);
                cuttingMax = 0;
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                GetKitchenObject().SetClearCounter(player);
            }
        }
    }
    public override void AltInteract(Player player)
    {

        if (HasKitchenObject() && HasRecipts(GetKitchenObject().GetKitchenObjectSO()))
        {
            cuttingMax++;
            KitchenObjectSO kitchenObjectSO = GetOutput(GetKitchenObject().GetKitchenObjectSO());
            SlicedObjects slicedObjects = GetSlicedObjects(GetKitchenObject().GetKitchenObjectSO());
            OnCutAnimations?.Invoke(this,EventArgs.Empty);
            OnProgressBar?.Invoke(this, new IProgressBar.OnProgressBarEventArgs
            {
                progress = (float)cuttingMax / slicedObjects.cuttingMax
            });
            if(cuttingMax == slicedObjects.cuttingMax)
            {
                GetKitchenObject().DestroyObject();
                KitchenObject.RespawnObject(kitchenObjectSO, this);
            }
            

        }


    }
    private bool HasRecipts(KitchenObjectSO kitchenObjectSO)
    {
        SlicedObjects slicedObject = GetSlicedObjects(kitchenObjectSO);
        {
            if (slicedObject != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    private KitchenObjectSO GetOutput (KitchenObjectSO kitchenObjectSO)
    {
        SlicedObjects slicedObject = GetSlicedObjects(kitchenObjectSO);
        {
            if (slicedObject != null)
            {
                return slicedObject.output;
            }
            else
            {
                return null;
            }
        }
    }

    private SlicedObjects GetSlicedObjects(KitchenObjectSO kitchenObject)
    {
        foreach (SlicedObjects slicedObject in slicedObjects)
        {
            if (slicedObject.input == kitchenObject)
            {
                return slicedObject;
            }
        } return null;
    }
}
