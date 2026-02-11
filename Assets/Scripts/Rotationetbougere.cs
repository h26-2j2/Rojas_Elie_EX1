using UnityEngine;

public class Rotationetbougere : MonoBehaviour
{
    public float positionMax = 12f;
    public float positionMin = -12f;
    public int vitesse;

    // VARIABLES CI DESSOUS TROUVÉS EN LIGNE POUR LOCALSCALE
    public Vector3 startScale = new Vector3(3f, 3f, 3f);
    public Vector3 maxScale = new Vector3(10f, 6f, 6f);
    public float duration = 1f; // temps en secondes entre les deux

    private float timer = 0f;
    private bool growing = true;

    void Start()
    {
        vitesse = Random.Range(1, 7);
    }

    void Update()
    {
        //rotation sur lui meme
        //transform.Rotate(0, 0, 360f * Time.deltaTime);
        transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);

        // il descend vers le bas
        transform.Translate(Vector2.down * vitesse * Time.deltaTime);

        // il revien a la position initiale (reset) quand il vas en bas de -12f
        if (transform.position.y < positionMin)
        {
            transform.position = new Vector2(transform.position.x, positionMax);
        }
        if (growing)
            timer += Time.deltaTime / duration;
        else
            timer -= Time.deltaTime / duration;



        //CODE TROUVÉ EN LIGNE DESSOUS POUR LE LOCALSCALE
    
        timer = Mathf.Clamp01(timer);

        // Scale entre le start scale jusquau maxscale
        transform.localScale = new Vector3(
            Mathf.Lerp(startScale.x, maxScale.x, timer),
            Mathf.Lerp(startScale.y, maxScale.y, timer),
            transform.localScale.z
        );

        // si on a atteint une des extrémités alors jinverse
        if (timer >= 1f) growing = false;
        if (timer <= 0f) growing = true;
    }
}
