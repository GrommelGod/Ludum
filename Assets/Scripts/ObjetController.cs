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

    // Start is called before the first frame update
    void Start()
    {
        var types = Enum.GetValues(typeof(TypeObjet)).Cast<TypeObjet>().ToArray();
        var randGen = UnityEngine.Random.Range(0, types.Count());
        currentType = types[randGen];
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
