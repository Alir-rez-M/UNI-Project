using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlateCounter : BaseCounter
{
    private float respawnTimer;
    private float maxRespawnTimer = 4f;
    private float plateVisual;
    private float maxPlateVisual =4f;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public event EventHandler OnRespawnPlateVisual;
    public event EventHandler OnRemovePlateVisual;

    private void Update()
    {
        respawnTimer += Time.deltaTime;
        if (respawnTimer > maxRespawnTimer)
        {
            respawnTimer = 0;
            plateVisual++;
            if (plateVisual <= maxPlateVisual)
            {
                OnRespawnPlateVisual?.Invoke(this, EventArgs.Empty);    
            }
        }
    }
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            if (plateVisual <= maxPlateVisual && plateVisual != 0)
            {
                plateVisual--;
                KitchenObject.RespawnObject(kitchenObjectSO, player);
                OnRemovePlateVisual?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
