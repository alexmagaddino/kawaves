using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{

    private Vector2 velocity;

    [SerializeField]
    private float smoothTimeX = 0f;
    [SerializeField]
    private float smoothTimeY = 0f;


    public bool bounds = true;

    public Vector3 minCamPos;
    public Vector3 maxCamPos;

    public GameObject player;

    float nextTimeToSearch;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Fascio");
    }

    void Update()
    {
        if (player == null)
        {
            FindPlayer();
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

            transform.position = new Vector3(posX, posY, -10);
            if (bounds)
            {
                transform.position = new Vector3(
                 Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x),
                 Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y),
                 Mathf.Clamp(-10, -10, -10)
                );
            }
        }
    }

    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Fascio");
            if (searchResult != null)
                player = searchResult;
            nextTimeToSearch = Time.time + 0.5f;
        }

    }
}