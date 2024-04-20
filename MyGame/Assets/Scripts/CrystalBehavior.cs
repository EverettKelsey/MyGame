using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalBehavior : MonoBehaviour
{
    public GameObject crystal;
    public GameBehavior _gameManager;
    public Text crystalText;
    [SerializeField] AudioClip clip;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            crystalText.enabled = true;
            StartCoroutine(DelayedLoad());
            _gameManager.Items += 1;
        }
    }

    IEnumerator DelayedLoad()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        Destroy(this.transform.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
        crystalText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
