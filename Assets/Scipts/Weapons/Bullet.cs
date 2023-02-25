using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int amountOfDamage;
    private float _distanceToDestroy = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        _distanceToDestroy += speed * Time.deltaTime;
        if(_distanceToDestroy >= 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log($"Trafiony: {other.gameObject.name}");
            other.GetComponent<Enemy>().Damage(amountOfDamage);
            Destroy(gameObject);

        }
    }

}


