using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Rigidbody rigBod;
    private int count;
    //public Text countText;
    //public Text winText;
    AudioSource audioSource = null;
    AudioClip collectClip = null;

    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
        count = 0;
        //SetCountText();
        //winText.text = "";
        
        // Add an AudioSource component and set up some defaults
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        //audioSource.spatialize = true;
        //audioSource.spatialBlend = 1.0f;
        //audioSource.dopplerLevel = 0.1f;
        //audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        //audioSource.maxDistance = 20f;

        // Load the Sphere sounds from the Resources folder
        collectClip = Resources.Load<AudioClip>("coin-collect");
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Do a raycast into the world that will only hit the Spatial Mapping mesh.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // Move the ball through gaze
            float moveHort = hitInfo.point.x;
            float moveVert = hitInfo.point.z;
            Vector3 movement = new Vector3(moveHort, 0.0f, moveVert);
            rigBod.AddForce(movement * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            audioSource.clip = collectClip;
            audioSource.Play();
            other.gameObject.SetActive(false);
            count++;
            //SetCountText();
        }
    }

    //void SetCountText()
    //{
    //    countText.text = "Score: " + count.ToString();
    //    if (count >= 14)
    //    {
    //        winText.text = "You Win!";
    //    }
    //}
}
