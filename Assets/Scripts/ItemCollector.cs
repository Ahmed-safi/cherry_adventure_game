using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherrys = 0;

    [SerializeField] private Text cherrysText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
           collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherrys++;
            cherrysText.text = "Cherries : " + cherrys;
        }
    }
}
