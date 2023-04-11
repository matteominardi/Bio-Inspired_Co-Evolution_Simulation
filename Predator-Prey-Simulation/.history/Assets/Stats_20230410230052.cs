using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    Camera mainCamera;
    ISelectable selectedObject;
    // Start is called before the first frame update
    void Start() 
    { 
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "SelectableObject")
            {
                print("clicked on " + hit.collider.gameObject.name);
                ISelectable obj;
                if (hit.collider.gameObject.name == "Predator")
                {
                    obj = hit.collider.gameObject.GetComponent<Predator>();
                }
                else if (hit.collider.gameObject.name == "Prey")
                {
                    obj = hit.collider.gameObject.GetComponent<Prey>();
                    
                }
                else
                {
                    return;
                }
                selectedObject = obj;
                string health = obj.Lifepoints.ToString();
                string fitness = obj.Fitness.ToString();
                string energy = obj.Energy.ToString();
                string speed = obj.Speed.ToString();
                string alive = obj.Alive.ToString();
                
                //print(gameObject.transform.Find("lblHealth").transform.Find("txtHealth").GetComponent<TMPro.TextMeshProUGUI>());//.transform.Find("txtHealth").GetComponents<MonoBehaviour>());
                gameObject.transform.Find("lblHealth").transform.Find("txtHealth").GetComponent<TMPro.TextMeshProUGUI>().text = health;
                gameObject.transform.Find("lblFitness").transform.Find("txtFitness").GetComponent<TMPro.TextMeshProUGUI>().text = fitness;
                gameObject.transform.Find("lblEnergy").transform.Find("txtEnergy").GetComponent<TMPro.TextMeshProUGUI>().text = energy;
                gameObject.transform.Find("lblSpeed").transform.Find("txtSpeed").GetComponent<TMPro.TextMeshProUGUI>().text = speed;
                gameObject.transform.Find("lblAlive").transform.Find("txtAlive").GetComponent<TMPro.TextMeshProUGUI>().text = alive;

                //GetComponent<TMPro.TextMeshProUGUI>().text = health;
            }

            //Debug.DrawRay(ray.origin, ray.direction * 300, Color.blue);
        }
        if (selectedObject != null)
        {
            string health = selectedObject.Lifepoints.ToString();
            string fitness = selectedObject.Fitness.ToString();
            string energy = selectedObject.Energy.ToString();
            string speed = selectedObject.Speed.ToString();
            string alive = selectedObject.Alive.ToString();
            
            //print(gameObject.transform.Find("lblHealth").transform.Find("txtHealth").GetComponent<TMPro.TextMeshProUGUI>());//.transform.Find("txtHealth").GetComponents<MonoBehaviour>());
            gameObject.transform.Find("lblHealth").transform.Find("txtHealth").GetComponent<TMPro.TextMeshProUGUI>().text = health;
            gameObject.transform.Find("lblFitness").transform.Find("txtFitness").GetComponent<TMPro.TextMeshProUGUI>().text = fitness;
            gameObject.transform.Find("lblEnergy").transform.Find("txtEnergy").GetComponent<TMPro.TextMeshProUGUI>().text = energy;
            gameObject.transform.Find("lblSpeed").transform.Find("txtSpeed").GetComponent<TMPro.TextMeshProUGUI>().text = speed;
            gameObject.transform.Find("lblAlive").transform.Find("txtAlive").GetComponent<TMPro.TextMeshProUGUI>().text = alive;
        }
        if () {
            selectedObject = null;
        }
    }
}
