using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Openable : Interactable
{
    public Sprite open;
    public Sprite close;
    public Collider2D col;
    public Player player;
    private SpriteRenderer sr;
    private bool isOpen;
    // Start is called before the first frame update
    public override void Interact()
    {
        
        if(isOpen)
        {
            sr.sprite = close;
            Debug.Log("open");
        }
        else
        {
            sr.sprite = open;
            Debug.Log("Close");
        }
        if (col.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Player>().Checkpoint = transform.position;
            FindObjectOfType<Player>().cekCheckpoint = true;
            player.SavePlayer();
        }

        isOpen = !isOpen;
    }

    // Update is called once per frame
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = close;
    }

    
}
