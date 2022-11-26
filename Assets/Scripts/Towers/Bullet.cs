using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject targetObject;
    public int bulletPower;
    public float moveSpeed;
    public float killDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetObject!=null)
        {
            transform.position = Vector3.Lerp(transform.position, targetObject.transform.position, Time.deltaTime * moveSpeed);
            Vector3 dir = targetObject.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            if (Vector3.Distance(transform.position,targetObject.transform.position)<killDistance)
            {
                targetObject.GetComponent<BaseUnitType>().ChangeHealth(-bulletPower);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
