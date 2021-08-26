using UnityEngine;
using System;
using System.Collections;

public class Fight2D : MonoBehaviour
{
    public static void Action(Vector2 point, float radius, int layerMask, float damage,Action<GameObject,float> callback)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << layerMask);

        if(colliders.Length>0)
        {
            callback(colliders[0].gameObject, damage);
        }
        else
        {
            callback(null, damage);

        }
    }
}