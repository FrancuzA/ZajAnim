using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public float movespeed = 1;

    private float animParameter;
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var MoveZ = Input.GetAxis("Vertical");
        var MoveX = Input.GetAxis("Horizontal");
        var i = math.clamp((math.abs(MoveX + MoveZ)), 0, 1);
        animator.SetFloat("MoveX", i);
        rb.linearVelocity = new Vector3(MoveX *movespeed,rb.linearVelocity.y , MoveZ *movespeed);
    }
}
