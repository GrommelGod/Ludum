using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject objetTenu;
    private TypeObjet? objetTenuType = null;

    protected EnemyType _type;

    public EnemyType Type
    {
        get
        {
            return _type;
        }
    }

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject itemPrefab;

    public AudioSource deathSound;

    private void Start()
    {
        var types = System.Enum.GetValues(typeof(TypeObjet)).Cast<TypeObjet>().ToArray();
        var randGen = UnityEngine.Random.Range(0, types.Count());
        objetTenuType = types[randGen];
    }

    private void Update()
    {
        var pos = transform.position;
        pos.x = pos.x + speed * Time.deltaTime;
        transform.position = pos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool fisted = collision.CompareTag("fist");
        Debug.Log(fisted);

        if (fisted)
        {

            if (deathSound != null)
            {
                deathSound.Play();
            }
            Destroy(gameObject);

            if (Type == EnemyType.Grandma)
            {
                GameStats.Instance.lives--;
            }

            if (objetTenuType != null)
            {
                var obj = GameObject.Instantiate(itemPrefab, transform.position, Quaternion.identity);
                obj.GetComponent<ObjetController>().SetItemType(objetTenuType.Value);
            }
        }
    }
}
