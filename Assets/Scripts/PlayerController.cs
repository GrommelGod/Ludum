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

    private Vector2 directionLook;

    Rigidbody2D body;

    [SerializeField]
    private GameObject fist;

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

        if (move.x != 0)
        {
            directionLook = move;
            directionLook.Normalize();
        }


        if (directionLook.x < 0)
        {
            _visual.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            _visual.GetComponent<SpriteRenderer>().flipX = false;
        }

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
        fist.SetActive(true);
        yield return new WaitForSeconds(.5f);
        fist.SetActive(false);
        _visual.GetComponent<SpriteRenderer>().sprite = _playerNeutral;
    }
}
