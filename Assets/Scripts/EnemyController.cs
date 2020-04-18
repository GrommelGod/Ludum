using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject objetTenu;
    private TypeObjet? objetTenuType = null;

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject itemPrefab;

    public EnemyController(float x, float y)
    {
        var pos = transform.position;
        pos.x = x;
        pos.y = y;
        transform.position = pos;
    }

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
            Destroy(gameObject);
            if (objetTenuType != null)
            {
                var obj = GameObject.Instantiate(itemPrefab, transform.position, Quaternion.identity);
                obj.GetComponent<ObjetController>().SetItemType(objetTenuType.Value);
            }
        }
    }
}
