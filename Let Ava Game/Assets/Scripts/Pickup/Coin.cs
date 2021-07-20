using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickup
{
    protected override void PickupEffect() {
        soundManager.PlayCoinCollect();
        gameManager.score += 1;
    }
}
