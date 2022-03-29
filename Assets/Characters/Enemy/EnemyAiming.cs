using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiming : CharacterAiming
{
    public float dispersion = 1f;
    public override GameObject SpawnBullet(Weapon weapon, Vector3 origin, Vector3 target)
    {
        GameObject go = base.SpawnBullet(weapon, origin, target);

        Vector2 MinMaxPair = getDispersionModifiers();
        float averageFromPair = (MinMaxPair.x + MinMaxPair.y) / 2;
        float range = dispersion * averageFromPair;

        float randomNumberX = Random.Range(-range, range);
        float randomNumberY = Random.Range(-range, range);
        float randomNumberZ = Random.Range(-range, range);

        go.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ);

        return go;
    }
}
