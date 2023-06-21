using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHP;
    [SerializeField] private float speed;

    private Transform target;
	GameManager gameManager;
    private void Awake()
    {
	    gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}

    void Update()
    {
		Vector3 direction = target.position - transform.position;
		direction.Normalize();

		transform.position += direction * speed * Time.deltaTime;
	}

    public void GetDamage(int damage)
    {
        enemyHP -= damage;
        if(enemyHP <= 0)
        {
            gameManager.PlusKillCount();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.GetDamaged();
            Destroy(gameObject);
        }
    }
}
