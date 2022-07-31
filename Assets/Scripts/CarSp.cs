using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSp : MonoBehaviour
{
    bool isUpgraded;
    float ver;
    float hor;
    float horSpeed = 6f;
    float verSpeed = 8f;
    public float rotateSpeed;
    public GameObject secondCar;
    public GameObject firstCar;
    BoxCollider myCollider;
    Rigidbody rb;
    


    void Start()
    {
        myCollider = firstCar.GetComponent<BoxCollider>();
        isUpgraded = false;
        rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;
    }

    
    void Update()
    {

        Movement();

        Rotation();

        Upgrade();
    }

    void Movement()
    {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(hor * horSpeed * Time.deltaTime, 0,  verSpeed * Time.deltaTime));
        
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        }

        else if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(- Vector3.up, rotateSpeed * Time.deltaTime);
        }

    }   


    void Upgrade()
    {
        if (verSpeed > 13 && isUpgraded == false)
        {
            //rb.isKinematic = false;
            transform.position = new Vector3(transform.localPosition.x, 1.79f, transform.localPosition.z);
            Destroy(firstCar);
            secondCar.transform.SetParent(this.transform);
            secondCar.transform.localPosition = new Vector3(0, 0, 0);
            secondCar.transform.localRotation = Quaternion.identity;
            //secondCar.transform.localRotation = this.transform.localRotation;
            //secondCar.transform.localPosition = this.transform.localPosition;
            isUpgraded = true;
            
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gas")
        {
            Destroy(other.gameObject);
            verSpeed += 3f;
        }

        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
            verSpeed -= 2f;
            
        }

        if(other.gameObject.tag == "100Points")
        {
            MenuLoader();
        }

        if(other.gameObject.tag == "Fail")
        {
            FailMenu();
        }
        
    }


    void MenuLoader()
    {
        SceneManager.LoadScene("LoadScene");
    }


    void FailMenu()
    {
        SceneManager.LoadScene("FailMenu");
    }
    
    
        
    
}
