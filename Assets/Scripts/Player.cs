using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody myRigiddody;
    public Vector3 moveDirection;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    void Start()
    {
        myRigiddody = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count: " + count.ToString();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveDirection.x, 0.0f,moveDirection.z);
        myRigiddody.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp Box"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count: " + count.ToString(); 
            if(count >= 33)
            {
                winText.text = "You Win!";
            }
        }
        
    }
}
