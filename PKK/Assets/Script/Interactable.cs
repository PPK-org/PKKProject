using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

   public abstract void Interact();

   private void OnTriggerStay2D(Collider2D collision)
   {
       if(collision.CompareTag("Player"))
        collision.GetComponent<Player>().OpenInterectableIcon();
   }

   private void OnTriggerExit2D(Collider2D collision)
   {
       if(collision.CompareTag("Player"))
        collision.GetComponent<Player>().CloseInterectableIcon();
   }
}
