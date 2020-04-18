using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private int speed;

    private TypeObjet? currentItem = null;

    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(x, y);

        Vector2 originPos = body.position;
        Vector2 newPos = originPos + move * speed * Time.deltaTime;

        body.MovePosition(newPos);

    }

    public void TakeItem(ObjetController objet)
    {

        if (currentItem == null)
        {
            currentItem = objet.ObjectType;
            Destroy(objet.gameObject);
            Debug.Log("Currently holding an item");
        }
    }

    public void DeliverItem()
    {
        if (currentItem != null)
        {
            Debug.Log("Dropping item");
            currentItem = null;
        }
    }
}
