using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Text HealthText;
    public int startHealth = 100;
    public int currentHealth { get; set; }

    float iTime; //iframes after damage
    float hTime; //hframes for healing speed

    // Start is called before the first frame update
    void Start(){
        currentHealth = startHealth;
        iTime = Time.time;
        hTime = Time.time;
    }

    // Update is called once per frame
    void Update(){
        HealthText.text = "Health: " + currentHealth;
        if(currentHealth == 0){ EndGame();}
        if((currentHealth < 100) && (Time.time - iTime > 10f)){ HealPlayer();}
    }
    private void OnTriggerEnter(Collider enemy){
        if (enemy.tag == "Zombie"){
            if(Time.time - iTime > 2.5f){
                if(currentHealth > 0){ currentHealth = currentHealth - 10;}
                if(currentHealth < 0){ currentHealth = 0;}
                iTime = Time.time;
            }
        }
    }
    private void EndGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void HealPlayer(){
        if(Time.time - hTime > .5f){
            currentHealth += 1;
            hTime = Time.time;
        }
    }
}
