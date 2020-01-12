using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * needs a dragged-in reference to projectile prefab
 * 
 * how do you manage projectiles once player leaves room? 
 * What if projectile goes through collider? (consider making a forced destroy if projectile exists for time > 20 sec)
 * 
 */


public class ProjectileInstantiator : MonoBehaviour
{
    //references
    public GameObject myProjectilePrefab; //prefab for cloning projectiles


    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Accessors

    //Mutators
    public void setProjectilePrefab(GameObject projectilePrefab)
    {
        myProjectilePrefab = projectilePrefab;
    }


    //Methods
    public void shootProjectile(Vector2 targetDirection, Vector2 currentPosition, float radiusFromTarget, float projectileSpeed)
    {
        //adds to sprite sorter? y or nay
        GameObject projectile = Instantiate(myProjectilePrefab, getProjectileStartingPosition(targetDirection, currentPosition, radiusFromTarget), getNewProjectileRotation(targetDirection, currentPosition));
        projectile.GetComponent<Rigidbody2D>().velocity = getNewProjectileVelocity(targetDirection, projectileSpeed);
    }

    //private methods
    private Vector2 getProjectileStartingPosition(Vector2 targetDirection, Vector2 currentPosition, float radiusFromTarget)
    {
        Vector2 radiusVector = targetDirection.normalized * radiusFromTarget;
        Vector2 position = currentPosition;
        return currentPosition + radiusVector;
    }
    private Quaternion getNewProjectileRotation(Vector2 targetDirection, Vector2 currentPosition)
    {
        float degrees = 90 + Mathf.Rad2Deg * Mathf.Atan(targetDirection.y / targetDirection.x);
        if (targetDirection.x < 0)   //corrects rotational issues with arctan's domain (or something)
        {
            degrees += 180;
        }
        return Quaternion.Euler(0, 0, degrees);
    }
    private Vector2 getNewProjectileVelocity(Vector2 targetDirection, float projectileSpeed)
    {
        return targetDirection.normalized * projectileSpeed;
    }


}
