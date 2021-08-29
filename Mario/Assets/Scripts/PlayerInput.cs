using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{

    private PlayerController _player;

    
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");


        

        _player.Move(hor);
            if(Input.GetButtonDown("Jump"))
        {
            _player.Jump();
        }
        
        if(Input.GetButtonDown("Submit"))
        {
            _player.Hit();
        }

    }



}
