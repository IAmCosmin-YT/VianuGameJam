using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterFall : MonoBehaviour
{
    [SerializeField] Sprite[] letters;
    [SerializeField] WordManager wordManager;

    public void SpawnGroupedLetters()
    {
        if (wordManager.currentWord.Length > 1)
        {
            int groupSize = Random.Range(1, wordManager.currentWord.Length); // Randomly determine the size of the letter group
            List<char> lettersInGroup = new List<char>();

            for (int i = 0; i < groupSize; i++)
            {
                char letter = wordManager.currentWord[i];
                lettersInGroup.Add(letter);
            }

            GameObject letterGroup = new GameObject();
            letterGroup.name = "GroupedLetters_";

            // Determine the random position around the center object
            float randomX = Random.Range(-6.5f, 6.5f); // Adjust the range as per your scene's requirements
            float randomY = Random.Range(-2.5f, 2.5f); // Adjust the range as per your scene's requirements
            float c = 0;

            foreach (char letter in lettersInGroup)
            {
                letterGroup.name += letter;
                // Spawn the letters at the specified random position
                GameObject letterObject = new GameObject("Letter" + "_" + letter);
                SpriteRenderer spriteRenderer = letterObject.AddComponent<SpriteRenderer>();
                PolygonCollider2D polygonCollider2D = letterObject.AddComponent<PolygonCollider2D>();
                Rigidbody2D rigidbody2D = letterObject.AddComponent<Rigidbody2D>();

                letterObject.transform.position = new Vector3(transform.position.x + randomX + c, transform.position.y + randomY, 0f);
                letterObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Random.Range(-20, 20));
                letterObject.transform.localScale = new Vector3(.2f, .2f, .2f); // Adjust the scale as per your desired size
                letterObject.tag = "Letter";

                polygonCollider2D.isTrigger = true;
                rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                rigidbody2D.constraints.Equals(true);

                spriteRenderer.sprite = GetSpriteForLetter(letter);
                c += 0.5f; // Adjust the spacing between letters

                letterObject.transform.parent = letterGroup.transform;
            }
        }
        else
        {
            char letter = wordManager.currentWord[0];

            // Determine the random position around the center object
            float randomX = Random.Range(-6.5f, 6.5f); // Adjust the range as per your scene's requirements
            float randomY = Random.Range(-2.5f, 2.5f); // Adjust the range as per your scene's requirements
            float c = 0;

            GameObject letterGroup = new GameObject();
            letterGroup.name = "GroupedLetters_";

            letterGroup.name += letter;
            // Spawn the letters at the specified random position
            GameObject letterObject = new GameObject("Letter" + "_" + letter);
            SpriteRenderer spriteRenderer = letterObject.AddComponent<SpriteRenderer>();
            PolygonCollider2D polygonCollider2D = letterObject.AddComponent<PolygonCollider2D>();
            Rigidbody2D rigidbody2D = letterObject.AddComponent<Rigidbody2D>();

            letterObject.transform.position = new Vector3(transform.position.x + randomX + c, transform.position.y + randomY, 0f);
            letterObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Random.Range(-20, 20));
            letterObject.transform.localScale = new Vector3(.2f, .2f, .2f); // Adjust the scale as per your desired size
            letterObject.tag = "Letter";

            polygonCollider2D.isTrigger = true;
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            rigidbody2D.constraints.Equals(true);

            spriteRenderer.sprite = GetSpriteForLetter(letter);
            c += 0.5f; // Adjust the spacing between letters

            letterObject.transform.parent = letterGroup.transform;
        }
    }

    private Sprite GetSpriteForLetter(char letter)
    {
        string letterName = letter.ToString().ToUpper(); // Get the uppercase letter name

        foreach (Sprite sprite in letters)
        {
            if (sprite.name == letterName)
            {
                return sprite;
            }
        }

        return null; // Return null if the sprite for the letter is not found
    }

    IEnumerator newLetterCombination()
    {
        yield return new WaitForSeconds(5f);
        SpawnGroupedLetters();
    }
}
