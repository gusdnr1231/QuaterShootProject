using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int speed;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject,2f);
            //���� Pool�� �ٲٱ�
        }
        else if (collision.gameObject.tag == "Wall ")
		{
			Destroy(gameObject, 2f);
			//���� Pool�� �ٲٱ�
		}
	}
}
