using Assets.Scripts.Enums;
using Assets.Scripts.Models;
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
    private GameObject fist;
    [SerializeField]
    private float _punchCooldown = .5f;

    private bool _hasPunched = false;
    private TypeObjet? currentItem = null;

    public bool HasItem
    {
        get
        {
            return currentItem != null;
        }
    }

    private Vector2 directionLook;

    Rigidbody2D body;

    [SerializeField]
    private GameObject itemDisplayer;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float currentSpeed = Mathf.Abs(x + y);

        animator.SetFloat("speed", currentSpeed);

        Vector2 move = new Vector2(x, y);

        if (move.x != 0)
        {
            directionLook = move;
            directionLook.Normalize();
        }


        if (directionLook.x < 0)
        {

            var scale = transform.localScale;
            scale.x = -0.75f;
            transform.localScale = scale;

            var itemPos = itemDisplayer.transform.position;
            itemPos.x = transform.position.x - 0.6f;
            itemDisplayer.transform.position = itemPos;
        }
        else if (directionLook.x > 0)
        {

            var scale = transform.localScale;
            scale.x = 0.75f;
            transform.localScale = scale;

            var itemPos = itemDisplayer.transform.position;
            itemPos.x = transform.position.x + 0.6f;
            itemDisplayer.transform.position = itemPos;

        }

        Vector2 originPos = body.position;
        Vector2 newPos = originPos + move * speed * Time.deltaTime;

        body.MovePosition(newPos);

        if (Input.GetButtonDown("Fire1"))
        {
            if (!_hasPunched)
            {
                animator.SetTrigger("Punching");
                StartCoroutine(Attack());
            }
        }
    }
    #region TakeItem
    public void TakeItem(ObjetController objet, Sprite itemSprite)
    {

        if (currentItem == null)
        {
            currentItem = objet.ObjectType;

            itemDisplayer.GetComponent<SpriteRenderer>().sprite = itemSprite;

            Destroy(objet.gameObject);
            Debug.Log("Currently holding an item");
        }
    }
    #endregion
    #region DeliverItem
    public void DeliverItem()
    {
        if (currentItem != null)
        {

            float pointsWinned = 0;

            switch (currentItem.Value)
            {
                case TypeObjet.Eggs:
                    pointsWinned = .5f;
                    break;
                case TypeObjet.Flour:
                    pointsWinned = .2f;
                    break;
                case TypeObjet.Mask:
                    pointsWinned = 1f;
                    break;
                case TypeObjet.Noodles:
                    pointsWinned = 1f;
                    break;
                case TypeObjet.ToiletPaper:
                    pointsWinned = 14f;
                    break;
            }

            GameStats.Instance.points += pointsWinned;
            itemDisplayer.GetComponent<SpriteRenderer>().sprite = null;
            currentItem = null;
        }
    }
    #endregion
    #region Attack
    private IEnumerator Attack()
    {
        _hasPunched = true;
        fist.SetActive(true);
        Debug.Log("Punch active");
        yield return new WaitForSeconds(.2f);
        fist.SetActive(false);
        Debug.Log("Punch Disabled");

        yield return new WaitForSeconds(_punchCooldown);
        _hasPunched = false;
    }
    #endregion
}
