using Assets.Scripts.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjetController : MonoBehaviour
{

    [SerializeField]
    private GameObject sprite;

    [SerializeField]
    private Sprite[] spritesPossibles;

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
        var winningSprite = spritesPossibles.Where(s => s.name == type.ToString()).FirstOrDefault();
        if (winningSprite != null)
        {
            sprite.GetComponent<SpriteRenderer>().sprite = winningSprite;
        }
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
