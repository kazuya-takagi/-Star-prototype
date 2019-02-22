using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchArea : MonoBehaviour
{

    // 水柱のアニメーター
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("WaterMove1", true);
        animator.SetBool("WaterMove2", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("WaterMove1", false);
        animator.SetBool("WaterMove2", true);
    }
}
