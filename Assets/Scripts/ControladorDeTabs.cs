using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Created by Luan Leme
public class ControladorDeTabs : MonoBehaviour
{
    private EventSystem system;
    [SerializeField] private GameObject firstFieldObj;
    
    void Start() // Start is called before the first frame update
    {
        system = EventSystem.current;
    }

    void Update() { // Update is called once per frame
        if( Input.GetKeyDown(KeyCode.Tab) ) {

            GameObject gameObj = system.currentSelectedGameObject;
            
            if(gameObj != null) {
                Selectable prox = gameObj.GetComponent<Selectable>();
                prox = prox.FindSelectableOnDown();
            
                // If there's not a next field below, select the first one
                if(prox == null)
                    prox = firstFieldObj.GetComponent<Selectable>();
    
                InputField inputfield = prox.GetComponent<InputField>();
                if (inputfield != null)
                    inputfield.OnPointerClick( new PointerEventData(system) );
                            
                system.SetSelectedGameObject(
                    prox.gameObject, new BaseEventData(system)
                );
            }
        }
    }
}
