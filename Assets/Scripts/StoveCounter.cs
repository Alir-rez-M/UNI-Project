using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoveCounter : BaseCounter ,  IProgressBar
{
    [SerializeField] FriedMeatSO friedMeatSO;
    [SerializeField] BurnedMeatSO burnedMeatSO;
    FriedMeatSO friedMeat;
    BurnedMeatSO burnedMeat;
    float friedMeatTime;
    float burnedMeatTime;
    private CookState mode;
    public event EventHandler<IProgressBar.OnProgressBarEventArgs> OnProgressBar;
    public enum CookState
    {
        Idle,
        FriedMeat,
        BurnedMeat,
        End,
    }
    public event EventHandler<OnCookingVisualEventArgs> OnCookingVisual;
    public class OnCookingVisualEventArgs : EventArgs
    {
        public CookState state;
    }
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject() && HasFriedMeatSORecip(player.GetKitchenObject().GetKitchenObjectSO()))
            {
                player.GetKitchenObject().SetClearCounter(this);
                friedMeat = GetFriedMeatSO(GetKitchenObject().GetKitchenObjectSO());
                StartCoroutine(FriedTimer(friedMeat.cookingDuration));
                mode = CookState.FriedMeat;

                
              
            }
        }
        else
        {
            if (HasKitchenObject())
            {
                if (player.HasKitchenObject())
                {
                    if(player.GetKitchenObject().TryGetPlateKitchenObject(out PlateKitchenObject plateKitchenObject))
                    {
                        Debug.Log("HIII");
                        if (plateKitchenObject.TryGetKitchenObjectSO(GetKitchenObject().GetKitchenObjectSO()))
                        {
                            GetKitchenObject().DestroyObject();
                            friedMeatTime = 0;
                            burnedMeatTime = 0;
                            StopAllCoroutines();
                            mode = CookState.Idle;
                            OnCookingVisual?.Invoke(this, new OnCookingVisualEventArgs
                            {
                                state = CookState.Idle,
                            });
                            OnProgressBar?.Invoke(this, new IProgressBar.OnProgressBarEventArgs
                            {
                                progress = 0f
                            });
                        }
                    }
                }
                else
                {
                    GetKitchenObject().SetClearCounter(player);
                    friedMeatTime = 0;
                    burnedMeatTime = 0;
                    StopAllCoroutines();
                    mode = CookState.Idle;
                    OnCookingVisual?.Invoke(this, new OnCookingVisualEventArgs
                    {
                        state = CookState.Idle,
                    });
                    OnProgressBar?.Invoke(this, new IProgressBar.OnProgressBarEventArgs
                    {
                        progress = 0f
                    });
                }
                

            }
        }
        
    }
    private void Start()
    {
        mode= CookState.Idle;
    }
    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (mode)
            {
                case CookState.Idle:
                    OnCookingVisual?.Invoke(this, new OnCookingVisualEventArgs
                    {
                        state = CookState.Idle,
                    });
                    break;
                case CookState.FriedMeat:
                    OnCookingVisual?.Invoke(this, new OnCookingVisualEventArgs
                    {
                        state = CookState.FriedMeat,
                    });
                    OnProgressBar?.Invoke(this, new IProgressBar.OnProgressBarEventArgs
                    {
                        progress = friedMeatTime / friedMeat.cookingDuration
                    });
                    if (friedMeatTime >= friedMeat.cookingDuration)
                    {
                        GetKitchenObject().DestroyObject();
                        KitchenObject.RespawnObject(friedMeat.cookedMeat, this);
                        burnedMeatTime = 0;
                        mode = CookState.BurnedMeat;
                    }
                    break;
                case CookState.BurnedMeat:
                    OnCookingVisual?.Invoke(this, new OnCookingVisualEventArgs
                    {
                        state = CookState.BurnedMeat,
                    });
                    OnProgressBar?.Invoke(this, new IProgressBar.OnProgressBarEventArgs
                    {
                        progress = burnedMeatTime / burnedMeat.burningDuration
                    });
                    if (burnedMeatTime >= burnedMeat.burningDuration)
                    {
                        GetKitchenObject().DestroyObject();
                        KitchenObject.RespawnObject(burnedMeat.burnedMeat, this);
                        mode = CookState.End;
                    }
                    break;
                case CookState.End:
                    OnCookingVisual?.Invoke(this, new OnCookingVisualEventArgs
                    {
                        state = CookState.End,
                    });
                    friedMeatTime = 0;
                    burnedMeatTime = 0;
                    break;
            }
            
        }
          
    }
    private IEnumerator FriedTimer( int friedDuration)
    {
        while (friedMeatTime <= friedDuration + Time.deltaTime)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            friedMeatTime += Time.deltaTime;
            
        }
        burnedMeat = GetBurnedMeatSO(GetKitchenObject().GetKitchenObjectSO());
        mode = CookState.BurnedMeat;


        StartCoroutine(BurnedTimer(burnedMeat.burningDuration));

    }
    private IEnumerator BurnedTimer( int burnedDuration)
    {
        while ( burnedMeatTime <= burnedDuration + Time.deltaTime)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            burnedMeatTime += Time.deltaTime;

        } 
        
    }
    
    private FriedMeatSO GetFriedMeatSO(KitchenObjectSO kitchenObjectSO)
    {
        if (friedMeatSO.uncookedMeat == kitchenObjectSO)
        {
            return friedMeatSO;
        }
        else
        {
            return null;
        }
    }
    private BurnedMeatSO GetBurnedMeatSO(KitchenObjectSO kitchenObjectSO)
    {
        if (burnedMeatSO.cookedMeat == kitchenObjectSO)
        {
            return burnedMeatSO;
        }
        else
        {
            return null;
        }
    }
    private bool HasFriedMeatSORecip(KitchenObjectSO kitchenObjectSO)
    {
        if (friedMeatSO.uncookedMeat == kitchenObjectSO)
        {
            return true;
        }
        return false;
    }
    private bool HasBurnedMeatSORecip(KitchenObjectSO kitchenObjectSO)
    {
        if (burnedMeatSO.cookedMeat == kitchenObjectSO)
        {
            return true;
        }
        return false;
    }
}
