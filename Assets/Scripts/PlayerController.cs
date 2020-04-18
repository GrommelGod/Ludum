using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private GameObject _visual;
    [SerializeField]
    private Sprite _playerAttack;
    [SerializeField]
    private Sprite _playerNeutral;

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

        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }
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

    private IEnumerator Attack()
    {
        _visual.GetComponent<SpriteRenderer>().sprite = _playerAttack;
        yield return new WaitForSeconds(.5f);
        _visual.GetComponent<SpriteRenderer>().sprite = _playerNeutral;
    }
}
