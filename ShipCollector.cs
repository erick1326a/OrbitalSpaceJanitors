using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollector : MonoBehaviour
{

private GameObject sattelite;
public int collectionstatus = 0;
private GameObject CollectionMessage;
private Animator collectionAnimator;
public bool collect = false;
public bool collidertriggered = false;
public string Victory;

    // Start is called before the first frame update
    void Start()
    {
         sattelite = GameObject.FindWithTag("Debris");
         CollectionMessage = GameObject.FindWithTag("CollectionMessage");
         collectionAnimator = CollectionMessage.GetComponent<Animator>();
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CollectionArea"))
        {
            
        collect = true;
        collectionstatus = 0;
            collecting();
       
          /*  collectionAnimator.SetInteger("Status", 1); 
           collectionAnimator.SetInteger("Status", 2); 
           collectionAnimator.SetInteger("Status", 3); 
           collectionAnimator.SetInteger("Status", 4); 
           collectionAnimator.SetInteger("Status", 5); 
           Destroy(sattelite);
        */
           
        }
        else{
            collect = false;
        }

     
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CollectionArea"))
        {
            
  collect = false;
  collectionstatus = 0;
  collectionAnimator.SetInteger("Status", 0);
       
        }

    }
		
    private void collecting(){
        
        if(collectionstatus<5 && collect == true){
            collectionstatus++;
            collectionAnimator.SetInteger("Status", collectionstatus);
        }
        else if(collect==true){
            Destroy(sattelite);
            collect = false;
			Application.LoadLevel(Victory);
        }

        
Invoke("collecting", 1f);

    }




    
}
