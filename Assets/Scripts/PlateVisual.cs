using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateVisual : MonoBehaviour
{
    [SerializeField] private Transform plateVisual;
    [SerializeField] private Transform plateVisualPosition;
    [SerializeField] private PlateCounter plateCounter;

    private List<GameObject> platesList;
    private void Start()
    {
        plateCounter.OnRespawnPlateVisual += PlateCounter_OnRespawnPlateVisual;
        plateCounter.OnRemovePlateVisual += PlateCounter_OnRemovePlateVisual;
        platesList = new List<GameObject>();    
    }

    private void PlateCounter_OnRemovePlateVisual(object sender, System.EventArgs e)
    {
        int lastPlateIndex = platesList.Count - 1; 
        GameObject lastPlate = platesList[lastPlateIndex];
        platesList.Remove(lastPlate);
        Destroy(lastPlate);
    }

    private void PlateCounter_OnRespawnPlateVisual(object sender, System.EventArgs e)
    {
        Transform respawnPlate = Instantiate(plateVisual, plateVisualPosition);
        float eachPlatePosition = 0.1f;
        respawnPlate.localPosition = new Vector3(0, platesList.Count * eachPlatePosition, 0);
        platesList.Add(respawnPlate.gameObject);
    }
    
}
