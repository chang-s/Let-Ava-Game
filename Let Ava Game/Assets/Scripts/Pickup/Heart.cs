using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Pickup
{
    protected override void PickupEffect() {
        player.health += 1;
        soundManager.PlayHeartCollect();
    }
}
