using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToMouse : MonoBehaviour
{
    public GameObject Projectile;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //get direction for projectile to travel
            Vector2 targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 currPos = new Vector2(transform.position.x, transform.position.y + 1);
            Vector2 direction = targetPos - currPos;
            direction.Normalize();

            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            GameObject temp = (GameObject)Instantiate(Projectile, currPos, rotation);
            temp.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
}
