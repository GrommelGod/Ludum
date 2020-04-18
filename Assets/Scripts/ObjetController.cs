using Assets.Scripts.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjetController : MonoBehaviour
{

    private TypeObjet currentType;
    public TypeObjet ObjectType
    {
        get
        {
            return currentType;
        }
    }

    public void SetItemType(TypeObjet type)
    {
        currentType = type;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            player.TakeItem(this);
        }
    }
}
