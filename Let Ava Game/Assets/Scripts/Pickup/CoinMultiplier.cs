using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMultiplier : Pickup
{
    public int newCoinRate;
    public float time;

    protected override void PickupEffect() {
        soundManager.PlayCoinCollect();
        gameManager.ChangeCoinRate(newCoinRate, time);
    }
}
