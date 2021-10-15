using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ControladorDeTabs : MonoBehaviour
{
    private EventSystem system;
    
    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;
    }

    // Update is called once per frame
    void Update() {
        if( Input.GetKeyDown(KeyCode.Tab) ) {

            GameObject gameObj = system.currentSelectedGameObject;
            if(gameObj != null) {
                Selectable prox = gameObj.GetComponent<Selectable>();
                prox = prox.FindSelectableOnDown();
            
                if(prox!= null) {         
                    InputField inputfield = prox.GetComponent<InputField>();
                    if (inputfield !=null)
                        inputfield.OnPointerClick( new PointerEventData(system) );
                                
                    system.SetSelectedGameObject(
                        prox.gameObject, new BaseEventData(system)
                    );
                }
            }
        }
    }
}
