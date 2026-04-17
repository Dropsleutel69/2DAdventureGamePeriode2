using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    // Sound effect played when collecting a coin
    public AudioClip coinClip;

    // Reference to the UI text that shows the coin count
    private TextMeshProUGUI coinText;

    private void Start()
    {
        // Find the UI element with the tag "CoinText" and get its TextMeshPro component
        coinText = GameObject.FindWithTag("CoinText").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug message to check if the trigger works
        Debug.Log("POOF");

        // Check if the player touched the coin
        if (collision.gameObject.tag == "Player")
        {
            // Get the Player script from the object
            Player player = collision.gameObject.GetComponent<Player>();

            // Increase the player's coin count
            player.coins += 1;

            // Play coin collection sound
            player.PlaySFX(coinClip, 0.4f);

            // Update the UI text with the new coin amount
            coinText.text = player.coins.ToString();

            // Destroy the coin object
            Destroy(gameObject);
        }
    }
}