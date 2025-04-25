using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] KitchenObjectSO KitchenObjectSO;
    IKitchenObject iKitchenObject;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return KitchenObjectSO;
    }
    public void SetClearCounter(IKitchenObject iKitchenObject)
    {
        if (this.iKitchenObject != null)
        {
            this.iKitchenObject.CleanKitchenObject();
            
        }
        this.iKitchenObject = iKitchenObject;
        if (iKitchenObject.HasKitchenObject())
        {

            Debug.LogError("THIS COUNTER HAS OBJECT......");
        }

        iKitchenObject.SetKitchenObject(this);
        transform.parent = iKitchenObject.GetRespawnPosition();
        transform.localPosition = Vector3.zero;
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    public bool TryGetPlateKitchenObject(out PlateKitchenObject plateKitchenObject)
    {
        if (this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        else
        {
            plateKitchenObject=null;
            return false;
        }
    }
    public static void RespawnObject(KitchenObjectSO kitchenObjectSO, IKitchenObject iKitchenObject)
    {
        Transform respawnObject = Instantiate(kitchenObjectSO.kitchenObject);
        respawnObject.transform.GetComponent<KitchenObject>().SetClearCounter(iKitchenObject);
    }

}
