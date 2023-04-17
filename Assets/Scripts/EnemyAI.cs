using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public bool isWalkingLeft = true;

    private bool grounded = false;

    private enum EnemyState {
        walking,
        falling,
        dead
    }
    private EnemyState state = EnemyState.falling;

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
        Fall();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyPosition ();
    }
    void UpdateEnemyPosition (){
        if(state != EnemyState.dead){
            Vector3 pos = transform.localPosition;
            Vector3 scale = transform.localScale;
            
            if(state == EnemyState.falling){
                pos.y += velocity.y * Time.deltaTime;
                
                velocity.y -= gravity * Time.deltaTime;
            }
            if(state == EnemyState.walking){
                if(isWalkingLeft){
                    pos.x -= velocity.x * Time.deltaTime;
                    
                    scale.x = -1;
                }
                else{
                    pos.x += velocity.x * Time.deltaTime;
                    
                    scale.x = +1;
                }
            }
            transform.localPosition = pos;
            transform.localScale = scale;
        }
    }

    Vector3 CheckGround(Vector 3 pos){
        
    }

    void private void OnBecameVisible() {
        enabled = true;
    }
    void Fall(){
        velocity.y = 0;
        state = EnemyState.falling;
        grounded = false;
    }
}
