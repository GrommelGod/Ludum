using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoggerController : EnemyController
{
    public JoggerController()
    {
        _type = Assets.Scripts.Enums.EnemyType.Jogger;
    }
}
