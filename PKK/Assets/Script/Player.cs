using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float MovementSpeed = 4;
    public float Jumpforce = 4;
    public int maxhealth = 100;
    public int currenthealth;
    public bool cekCheckpoint = false;
    public int level;
    float nextHittime= 0f;
    public float hitRate = 2f;
    public int eventCount;
    private Vector2 boxSize = new Vector2(0.1f,1f);
    public GameObject playerplay;
    private Rigidbody2D _rigidbody;
    public Animator animator;
    public Collider2D col;
    public HealthBar healthBar;
    public GameObject interaction;
    public Vector2 Checkpoint;
    public Vector3 position;
    [SerializeField]
    GameObject Hero;
    // Start is called before the first frame update
    void Start()
    {
        if(DataPlayer.Resume == true)
        {   
            
            position.x = DataPlayer.xposition;
            position.y = DataPlayer.yposition;
            position.z = DataPlayer.zposition;
            transform.position = position;
            
        }
        if (DataPlayer.backscene == true)
        {
            position.x = DataPlayer.xposition;
            position.y = DataPlayer.yposition;
            position.z = DataPlayer.zposition;
            transform.position = position;
        }
        DataPlayer.eventPlay = false;
        level = SceneManager.GetActiveScene().buildIndex;
        currenthealth = DataPlayer.currenthealth;
        _rigidbody = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(maxhealth);
        healthBar.SetHealth(currenthealth);
        Checkpoint = _rigidbody.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        eventCount = DataPlayer.eventCount;
        if (DataPlayer.eventPlay == false)
        {
            var movement = Input.GetAxis("Horizontal") * MovementSpeed;
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime ;
            animator.SetFloat("isWalking", Mathf.Abs(movement));
            if (!Mathf.Approximately(0, movement))
            {

                transform.rotation = -movement > 0 ? Quaternion.Euler(0,-200,0) : Quaternion.identity;
            }

            if (Input.GetKeyDown(KeyCode.X) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                _rigidbody.AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
                animator.SetBool("isJump", true);
            
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                CheckInteraction();
            }
        }
    
    }
    
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("isHit");
        
        currenthealth -= damage;

        if (currenthealth <= 0)
        {
            Die();
        }

        healthBar.SetHealth(currenthealth);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "platform")
        {
            animator.SetBool("isJump", false);
        }
    }
    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direcition = (obj.transform.position - this.transform.position).normalized;
            _rigidbody.AddForce(-direcition * knockbackPower);
        }

        yield return 0;
    }
    public void OpenInterectableIcon()
    {

    }
    public void CloseInterectableIcon()
    {
        
    }
    public void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach (RaycastHit2D rc in hits)
            {
                if (rc.IsInteractable())
                {
                    currenthealth = maxhealth;
                    healthBar.SetHealth(currenthealth);
                    rc.Interact();
                    return;
                }
            }
        }
    }
    void Die()
    {
        DataPlayer.currenthealth = maxhealth;
        Debug.Log("Player Die");
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        Destroy(gameObject, 1f);
        yield return new WaitForSeconds(0.9f);
        if(cekCheckpoint == true)
        {
            Instantiate(Hero, Checkpoint, Quaternion.identity);
        }else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    
}
