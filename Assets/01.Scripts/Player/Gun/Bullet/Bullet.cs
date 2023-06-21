using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int speed;
    public float deadTime;

    private void Awake()
    {
		Destroy(gameObject, deadTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
		{
			Destroy(gameObject, 2f);
			//���� Pool�� �ٲٱ�
		}
        else if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.GetDamage(damage);
        }
    }
}
