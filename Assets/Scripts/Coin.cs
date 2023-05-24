using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 0 , 0); //to define the rotation angle of coin along x_axis(50 ==> speed of rotation)
    }
    private void OnTriggerEnter(Collider other) //method to collect coins and display number of coins
    {
        if(other.tag == "Player") // when player hit coin
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin"); // to play the sound PickUpCoin when player take a coin
            PlayerManager.numberOfCoins += 1 ; // increase variable of numberofcoins by one
            Destroy(gameObject); // to remove the coin that the player hit(take)
        }
    }
}
