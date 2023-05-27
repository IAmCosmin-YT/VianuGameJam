using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterFall : MonoBehaviour
{
    [SerializeField] Sprite[] letters;
    [SerializeField] WordManager wordManager;
    [SerializeField] ParticleSystem particle;
    [SerializeField] Animator animator;

    public void SpawnGroupedLetters()
    {
        if (wordManager.currentWord.Length > 1)
        {
            string newWord = wordManager.currentWord;
            int currWordLenght = wordManager.currentWord.Length;


            // Determine the random position around the center object
            float randomX = Random.Range(-7.5f, 7.5f); // Adjust the range as per your scene's requirements
            float randomY = Random.Range(-3.5f, 3.5f); // Adjust the range as per your scene's requirements
            float c = 0;
            char oldLetter = char.MaxValue;


            for (int i = 0; i < 2; i++)
            {
                char letter = newWord[Random.Range(0, currWordLenght)];
                if (letter != oldLetter)
                {
                    // Spawn the letters at the specified random position
                    GameObject letterObject = new GameObject("Letter" + "_" + letter);
                    SpriteRenderer spriteRenderer = letterObject.AddComponent<SpriteRenderer>();
                    PolygonCollider2D polygonCollider2D = letterObject.AddComponent<PolygonCollider2D>();
                    Rigidbody2D rigidbody2D = letterObject.AddComponent<Rigidbody2D>();
                    UnityEditorInternal.ComponentUtility.CopyComponent(animator);
                    UnityEditorInternal.ComponentUtility.PasteComponentAsNew(letterObject);
                    UnityEditorInternal.ComponentUtility.CopyComponent(particle);
                    UnityEditorInternal.ComponentUtility.PasteComponentAsNew(letterObject);

                    letterObject.transform.position = new Vector3(transform.position.x + randomX + c, transform.position.y + randomY, 0f);
                    letterObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Random.Range(-20, 20));
                    letterObject.transform.localScale = new Vector3(.3f, .3f, .3f); // Adjust the scale as per your desired size
                    letterObject.tag = "Letter";

                    polygonCollider2D.isTrigger = true;
                    rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                    rigidbody2D.constraints.Equals(true);

                    spriteRenderer.sprite = GetSpriteForLetter(letter);
                    c += 0.5f; // Adjust the spacing between letters
                }
                else i--;
                oldLetter = letter;
            }
        }
        else
        {
            char letter = wordManager.currentWord[0];

            // Determine the random position around the center object
            float randomX = Random.Range(-7.5f, 7.5f); // Adjust the range as per your scene's requirements
            float randomY = Random.Range(-3.5f, 3.5f); // Adjust the range as per your scene's requirements
            float c = 0;
            // Spawn the letters at the specified random position
            GameObject letterObject = new GameObject("Letter" + "_" + letter);
            SpriteRenderer spriteRenderer = letterObject.AddComponent<SpriteRenderer>();
            PolygonCollider2D polygonCollider2D = letterObject.AddComponent<PolygonCollider2D>();
            Rigidbody2D rigidbody2D = letterObject.AddComponent<Rigidbody2D>();

            letterObject.transform.position = new Vector3(transform.position.x + randomX + c, transform.position.y + randomY, 0f);
            letterObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Random.Range(-20, 20));
            letterObject.transform.localScale = new Vector3(.3f, .3f, .3f); // Adjust the scale as per your desired size
            letterObject.tag = "Letter";

            polygonCollider2D.isTrigger = true;
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            rigidbody2D.constraints.Equals(true);

            spriteRenderer.sprite = GetSpriteForLetter(letter);
            c += 0.5f; // Adjust the spacing between letters
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
